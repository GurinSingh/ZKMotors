using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Respositories.Sales
{
    public interface ISaleHistoryRepository
    {
        Task<int> AddSaleHistoryAsync(Entities.Sales.SaleHistory saleHistory);
        Task<Entities.Sales.SaleHistory> GetSaleHistoryByIdAsync(int saleHistoryId);
        Task<IEnumerable<Entities.Sales.SaleHistory>> GetAllSaleHistoriesAsync();
        Task UpdateSaleHistoryAsync(Entities.Sales.SaleHistory saleHistory);
        Task DeleteSaleHistoryAsync(int saleHistoryId);
    }
}
