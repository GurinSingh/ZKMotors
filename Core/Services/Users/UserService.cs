using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Users;
using ZK.Domain.Entities.Users;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Users;

namespace ZK.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task CreateAsync(AddUserDTO addUserDTO, CancellationToken cancellationToken)
        {
            await this._repositoryManager.UserRepository.AddAsync(this.MapToEntity(addUserDTO), cancellationToken);
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            await this._repositoryManager.UserRepository.DeleteAsync(new User { UserId = Id }, cancellationToken);
        }

        public async Task<IEnumerable<ViewUserDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await this._repositoryManager.UserRepository.GetAllAsync(cancellationToken);
            return users.Select(u => this.MapToDTO(u)).ToList();
        }

        public async Task<ViewUserDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var user = await this._repositoryManager.UserRepository.GetByIdAsync(id, cancellationToken);
            return this.MapToDTO(user);
        }

        public async Task<ViewUserDTO> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await this._repositoryManager.UserRepository.GetAsync(u=> u.UserName == userName, cancellationToken);
            return this.MapToDTO(user);
        }

        public async Task UpdateAsync(UpdateUserDTO updateUserDTO, CancellationToken cancellationToken)
        {
            await this._repositoryManager.UserRepository.UpdateAsync(this.MapToEntity(updateUserDTO), cancellationToken);
        }

        #region private methods
        private User MapToEntity(AddUserDTO userDTO)
        {
            return new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                UserName = userDTO.UserName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
        private User MapToEntity(UpdateUserDTO userDTO)
        {
            return new User
            {
                UserId = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                UserName = userDTO.UserName,
                UpdatedAt = DateTime.UtcNow
            };
        }
        private ViewUserDTO MapToDTO(User user)
        {
            return new ViewUserDTO
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
        #endregion
    }
}
