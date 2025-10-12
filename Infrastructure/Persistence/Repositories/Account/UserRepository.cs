using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Users;
using ZK.Domain.Respositories.Account;

namespace ZK.Persistence.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly ZKDbContext _context;
        public UserRepository(ZKDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity, CancellationToken cancellationToken)
        {
            await this._context.Users.AddAsync(entity);
        }

        public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
        {
            this._context.Users.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Users.ToListAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.Users.FindAsync(id, cancellationToken);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken)
        {
            return await this._context.Users.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            this._context.Users.Update(entity);
            await Task.CompletedTask;
        }
    }
}
