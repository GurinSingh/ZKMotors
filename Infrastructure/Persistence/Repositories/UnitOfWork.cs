using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories;

namespace ZK.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZKDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task BeginTransactionAsync()
        {
            if(this._transaction != null)
                throw new InvalidOperationException("Transaction already started");
            
            this._transaction = await this._context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if(this._transaction == null)
                throw new InvalidOperationException("No transaction started");

            try
            {
                await this._transaction.CommitAsync();
            }
            catch
            {
                await this._transaction.RollbackAsync();
                throw new Exception("Operation failed.");
            }
            finally
            {
                await this._transaction.DisposeAsync();
                this._transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if(this._transaction == null)
                throw new InvalidOperationException("No transaction started");

            await this._transaction.RollbackAsync();
            await this._transaction.DisposeAsync();
            this._transaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}
