using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Users;

namespace ZK.Domain.Respositories.Account
{
    public interface IUserRoleRepository: IBaseRepository<UserRole>
    {
        Task AddRangeAsync(IEnumerable<UserRole> entity, CancellationToken cancellationToken);
        Task<IEnumerable<UserRole>> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    }
}
