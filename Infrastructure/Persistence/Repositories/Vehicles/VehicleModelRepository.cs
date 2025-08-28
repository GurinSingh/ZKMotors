using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Persistence.Repositories.Vehicles
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ZKDbContext _context;
        public VehicleModelRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(VehicleModel vehicleModel, CancellationToken cancellationToken = default)
        {
            await this._context.VehicleModels.AddAsync(vehicleModel, cancellationToken);
        }

        public async Task<IEnumerable<VehicleModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.VehicleModels.ToListAsync(cancellationToken);
        }

        public async Task<VehicleModel> GetByIdAsync(int vehicleModelId, CancellationToken cancellationToken = default)
        {
            return await this._context.VehicleModels.FindAsync(vehicleModelId, cancellationToken).AsTask();
        }
    }
}
