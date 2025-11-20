using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Users;

namespace ZK.Services.Abstractions.Users
{
    public interface IUserService
    {
        Task CreateAsync(AddUserDTO addUserDTO, CancellationToken cancellationToken);
        Task DeleteAsync(int Id, CancellationToken cancellationToken);
        Task<ViewUserDTO> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ViewUserDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(UpdateUserDTO updateUserDTO, CancellationToken cancellationToken);
        Task<ViewUserDTO> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
    }
}
