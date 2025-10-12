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
    public class RoleClaimRepository : IRoleClaimRepository
    {
        private readonly ZKDbContext _context;
        public RoleClaimRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(RoleClaim entity, CancellationToken cancellationToken)
        {
            await this._context.RoleClaims.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(RoleClaim entity, CancellationToken cancellationToken)
        {
            this._context.RoleClaims.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<RoleClaim>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.RoleClaims.ToListAsync(cancellationToken);
        }

        public async Task<RoleClaim> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.RoleClaims.FindAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(RoleClaim entity, CancellationToken cancellationToken)
        {
            this._context.RoleClaims.Update(entity);
            await Task.CompletedTask;
        }
    }
}
