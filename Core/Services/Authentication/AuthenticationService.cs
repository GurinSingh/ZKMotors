using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Account;
using ZK.Contracts.DTOs.Users;
using ZK.Domain.Entities.Users;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Account;

namespace ZK.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(IRepositoryManager repositoryManager, IConfiguration configuration, SignInManager<User> signInManager)
        {
            this._repositoryManager = repositoryManager;
            this._configuration = configuration;
            this._passwordHasher = new PasswordHasher<User>();
            this._signInManager = signInManager;
        }

        public async Task<LoginResponseDTO> SignInAsync(LoginRequestDTO loginRequest, CancellationToken cancellationToken)
        {
            if(loginRequest == null)
                throw new ArgumentNullException(nameof(loginRequest));

            if(string.IsNullOrWhiteSpace(loginRequest.UserName) || string.IsNullOrWhiteSpace(loginRequest.Password))
                throw new ArgumentException("Username and password must be provided.");

            var user = await this._repositoryManager.UserRepository.GetAsync(u => u.UserName == loginRequest.UserName, cancellationToken);
            if (!await this.VerifyPassword(user, loginRequest.Password, cancellationToken))
                throw new UnauthorizedAccessException("Invalid username or password.");

            //var result = await this._signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, true, false);
            await this._signInManager.SignInAsync(user, true);

            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(Convert.ToInt16(this._configuration["JwtConfig:TokenExpiryInMinutes"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, loginRequest.UserName)
                }),
                Issuer = this._configuration["JwtConfig:Issuer"],
                Audience = this._configuration["JwtConfig:Audience"],
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JwtConfig:key"])),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = loginRequest.UserName,
                Roles = (await this._repositoryManager.UserRoleRepository.GetByUserIdAsync(user.UserId, cancellationToken)).Select(ur => new ViewRoleDTO { RoleId = ur.RoleId, Name = ur.Role.Name }).ToList(),
                Token = tokenHandler.WriteToken(securityToken),
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }
        public async Task<bool> RegisterAsync(RegisterRequestDTO registerRequest, CancellationToken cancellationToken)
        {
            if (registerRequest == null)
                throw new ArgumentNullException(nameof(registerRequest));
            if (string.IsNullOrWhiteSpace(registerRequest.UserName) || string.IsNullOrWhiteSpace(registerRequest.Password))
                throw new ArgumentException("Username and password must be provided.");
            var existingUser = await this._repositoryManager.UserRepository.GetAsync(u => u.UserName == registerRequest.UserName, cancellationToken);
            if (existingUser != null)
                throw new InvalidOperationException("User with the same username already exists.");
            var user = new User
            {
                UserName = registerRequest.UserName,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                CreatedAt = DateTime.UtcNow,
            };
            user.PasswordHash = this._passwordHasher.HashPassword(user, registerRequest.Password);

            try
            {
                await this._repositoryManager.UnitOfWork.BeginTransactionAsync();

                await this._repositoryManager.UserRepository.AddAsync(user, cancellationToken);
                await this._repositoryManager.UnitOfWork.SaveChangesAsync();

                await this._repositoryManager.UserRoleRepository.AddRangeAsync(registerRequest.RoleIds.Select(ri => new UserRole { RoleId = ri, UserId = user.UserId }), cancellationToken);
                await this._repositoryManager.UnitOfWork.SaveChangesAsync();

                await this._repositoryManager.UnitOfWork.CommitTransactionAsync();
            }
            catch
            {
                await this._repositoryManager.UnitOfWork.RollbackTransactionAsync();
                throw;
            }
            
            return true;
        }

        private async Task<bool> VerifyPassword(User user, string password, CancellationToken cancellationToken)
        {
            if (user is null || string.IsNullOrEmpty(user.PasswordHash))
                return false;

            var verificationResult = this._passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if(verificationResult == PasswordVerificationResult.Failed)
                return false;

            if(verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = this._passwordHasher.HashPassword(user, password);
                await this._repositoryManager.UserRepository.UpdateAsync(user, cancellationToken);
                await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            }

            return true;
        }
    }
}
