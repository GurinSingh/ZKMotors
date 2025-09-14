using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace ZK.Persistence.Repositories.Vehicles
{
    public class VehicleImageRepository : IVehicleImageRepository
    {
        private readonly ZKDbContext _context;
        public VehicleImageRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task<VehicleImage> GetAsync(Expression<Func<VehicleImage, bool>> predicate, CancellationToken cancellationToken)
        {
            return await this._context.VehicleImages.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<VehicleImage>> GetByVehicleIdAsync(int vehicleId, CancellationToken cancellationToken)
        {
            return await this._context.VehicleImages.Where(vi => vi.VehicleId == vehicleId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<VehicleImage>> GetManyAsync(Expression<Func<VehicleImage, bool>> predicate, CancellationToken cancellationToken)
        {
            return await this._context.VehicleImages.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task DeleteAllbyVehicleIdAsync(int vehicleId, CancellationToken cancellationToken)
        {
            var images = this._context.VehicleImages.Where(vi => vi.VehicleId == vehicleId);
            if (images.Any())
                this._context.VehicleImages.RemoveRange(images);

            await Task.CompletedTask;
        }
    }
}
