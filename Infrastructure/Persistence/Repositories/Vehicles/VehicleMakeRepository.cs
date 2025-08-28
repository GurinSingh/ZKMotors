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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly ZKDbContext _context;
        public VehicleMakeRepository(ZKDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(VehicleMake vehicleMake, CancellationToken cancellationToken = default)
        {
            await this._context.VehicleMakes.AddAsync(vehicleMake, cancellationToken);
        }

        public async Task<IEnumerable<VehicleMake>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.VehicleMakes.ToListAsync(cancellationToken);
        }

        public async Task<VehicleMake> GetByIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default)
        {
            return await this._context.VehicleMakes.FindAsync(vehicleMakeId, cancellationToken);
        }
    }
}
