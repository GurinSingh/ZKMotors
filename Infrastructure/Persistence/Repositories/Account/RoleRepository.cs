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
    public class RoleRepository : IRoleRepository
    {
        private readonly ZKDbContext _context;
        public RoleRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(Role entity, CancellationToken cancellationToken)
        {
            await this._context.Roles.AddAsync(entity);
        }

        public async Task DeleteAsync(Role entity, CancellationToken cancellationToken)
        {
            this._context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Roles.ToListAsync(cancellationToken);
        }

        public async Task<Role> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.Roles.FindAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(Role entity, CancellationToken cancellationToken)
        {
            this._context.Roles.Update(entity);
            await Task.CompletedTask;
        }
    }
}
