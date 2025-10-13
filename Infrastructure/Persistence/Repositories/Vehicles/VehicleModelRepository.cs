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

        public async Task<IEnumerable<VehicleModel>> GetByMakeIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default)
        {
            return await this._context.VehicleModels
                .Where(vm => vm.MakeId == vehicleMakeId)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(VehicleModel vehicleModel, CancellationToken cancellationToken = default)
        {
            this._context.VehicleModels.Update(vehicleModel);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(VehicleModel vehicleModel, CancellationToken cancellationToken = default)
        {
            this._context.VehicleModels.Remove(vehicleModel);
            await Task.CompletedTask;
        }
    }
}
