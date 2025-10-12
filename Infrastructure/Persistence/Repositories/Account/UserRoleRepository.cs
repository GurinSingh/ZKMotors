using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Users;
using ZK.Domain.Respositories.Account;

namespace ZK.Persistence.Repositories.Account
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ZKDbContext _context;
        public UserRoleRepository(ZKDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserRole entity, CancellationToken cancellationToken)
        {
            await this._context.UserRoles.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<UserRole> userRoles, CancellationToken cancellationToken)
        {
            await this._context.UserRoles.AddRangeAsync(userRoles, cancellationToken);
        }

        public async Task DeleteAsync(UserRole entity, CancellationToken cancellationToken)
        {
            this._context.UserRoles.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.UserRoles.Include(ur=> ur.Role).ToListAsync(cancellationToken);
        }

        public async Task<UserRole> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.UserRoles.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<UserRole>> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await this._context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(UserRole entity, CancellationToken cancellationToken)
        {
            this._context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
