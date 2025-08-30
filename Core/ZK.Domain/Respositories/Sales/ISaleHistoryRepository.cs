using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Sales;

namespace ZK.Domain.Respositories.Sales
{
    public interface ISaleHistoryRepository
    {
        Task AddAsync(SaleHistory saleHistory, CancellationToken cancellationToken);
        Task<SaleHistory> GetByIdAsync(int saleHistoryId, CancellationToken cancellationToken);
        Task<IEnumerable<SaleHistory>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(SaleHistory saleHistory, CancellationToken cancellationToken);
    }
}
