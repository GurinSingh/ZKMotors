using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Sales;

namespace ZK.Domain.Respositories.Sales
{
    public interface ISaleHistoryRepository: IBaseRepository<SaleHistory>
    {
        Task<decimal> GetTotalRevenueAsync(CancellationToken cancellationToken);
    }
}
