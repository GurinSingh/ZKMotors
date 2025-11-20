using Microsoft.EntityFrameworkCore;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Persistence.Repositories.Vehicles
{
    internal class DrivetrainRepository : IDrivetrainRepository
    {
        private readonly ZKDbContext _context;
        public DrivetrainRepository(ZKDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Drivetrain entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Drivetrain entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Drivetrain>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Drivetrains.ToListAsync(cancellationToken);
        }

        public async Task<Drivetrain> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.Drivetrains.FindAsync(id, cancellationToken);
        }

        public Task UpdateAsync(Drivetrain entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
