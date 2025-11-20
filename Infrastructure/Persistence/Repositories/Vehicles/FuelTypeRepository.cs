using Microsoft.EntityFrameworkCore;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Persistence.Repositories.Vehicles
{
    internal class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly ZKDbContext _context;
        public FuelTypeRepository(ZKDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(FuelType entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(FuelType entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FuelType>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.FuelTypes.ToListAsync(cancellationToken);
        }

        public async Task<FuelType> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.FuelTypes.FindAsync(id, cancellationToken);
        }

        public Task UpdateAsync(FuelType entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
