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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ZKDbContext _context;
        public VehicleRepository(ZKDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
        {
            await this._context.Vehicles.AddAsync(vehicle, cancellationToken);
        }

        public async Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken)
        {
            this._context.Vehicles.Update(vehicle);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Where(v=> !v.Sold).Include(p=>p.Make).Include(p=>p.Model).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Vehicle>> GetAllIncludingSoldOutAsync(CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Include(p => p.Make).Include(p => p.Model).ToListAsync(cancellationToken);
        }

        public async Task<Vehicle> GetByIdAsync(int vehicleId, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.FindAsync(vehicleId, cancellationToken);
        }

        public async Task<Vehicle> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Include(v=>v.Make).Include(v=>v.Model).FirstOrDefaultAsync(v => v.Slug == slug, cancellationToken);
        }

        public async Task<IEnumerable<Vehicle>> GetByMakeIdAsync(int makeId, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Where(v => v.MakeId == makeId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Vehicle>> GetByModelIdAsync(int modelId, CancellationToken cancellationToken)
        {
            return await this._context.Vehicles.Where(v => v.ModelId == modelId).ToListAsync(cancellationToken);
        }
    }
}
