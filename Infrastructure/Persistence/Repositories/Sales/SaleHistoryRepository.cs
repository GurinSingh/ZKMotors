using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Sales;
using ZK.Domain.Respositories.Sales;

namespace ZK.Persistence.Repositories.Sales
{
    public class SaleHistoryRepository: ISaleHistoryRepository
    {
        private readonly ZKDbContext _context;
        public SaleHistoryRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(SaleHistory saleHistory, CancellationToken cancellationToken)
        {
            await this._context.SaleHistories.AddAsync(saleHistory, cancellationToken);
        }

        public async Task<IEnumerable<SaleHistory>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.SaleHistories.ToListAsync(cancellationToken);
        }

        public async Task<SaleHistory> GetByIdAsync(int saleHistoryId, CancellationToken cancellationToken)
        {
            return await this._context.SaleHistories.FindAsync(saleHistoryId, cancellationToken);
        }

        public async Task UpdateAsync(SaleHistory saleHistory, CancellationToken cancellationToken)
        {
            this._context.SaleHistories.Update(saleHistory);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(SaleHistory saleHistory, CancellationToken cancellationToken)
        {
            this._context.SaleHistories.Remove(saleHistory);
            await Task.CompletedTask;
        }

        public async Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken)
        {
            return await this._context.SaleHistories.SumAsync(sh => sh.SalePrice, cancellationToken);
        }
    }
}
