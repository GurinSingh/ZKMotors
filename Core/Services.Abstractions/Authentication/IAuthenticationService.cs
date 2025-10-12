using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Account;
using ZK.Domain.Respositories;

namespace ZK.Services.Abstractions.Account
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO> SignInAsync(LoginRequestDTO loginRequest, CancellationToken cancellationToken);
        Task<bool> RegisterAsync(RegisterRequestDTO registerRequest, CancellationToken cancellationToken);
    }
}
