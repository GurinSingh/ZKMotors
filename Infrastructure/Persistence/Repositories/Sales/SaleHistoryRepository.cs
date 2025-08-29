using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories.Sales;

namespace ZK.Persistence.Repositories.Sales
{
    public class SaleHistoryRepository
    {
        private readonly ZKDbContext _context;
        public SaleHistoryRepository(ZKDbContext context)
        {
            _context = context;
        }

        //public async Task<int> AddSaleHistoryAsync(Domain.Entities.Sales.SaleHistory saleHistory)
        //{
        //    await _context.SaleHistories.AddAsync(saleHistory);
        //}

        //public Task DeleteSaleHistoryAsync(int saleHistoryId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Domain.Entities.Sales.SaleHistory>> GetAllSaleHistoriesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Domain.Entities.Sales.SaleHistory> GetSaleHistoryByIdAsync(int saleHistoryId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateSaleHistoryAsync(Domain.Entities.Sales.SaleHistory saleHistory)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
