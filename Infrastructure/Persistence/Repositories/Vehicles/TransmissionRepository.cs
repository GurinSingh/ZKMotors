using Microsoft.EntityFrameworkCore;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Persistence.Repositories.Vehicles
{
    internal class TransmissionRepository : ITransmissionRepository
    {
        private readonly ZKDbContext _context;
        public TransmissionRepository(ZKDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Transmission entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Transmission entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transmission>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Transmissions.ToListAsync(cancellationToken);
        }

        public async Task<Transmission> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.Transmissions.FindAsync(id, cancellationToken);
        }

        public Task UpdateAsync(Transmission entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
