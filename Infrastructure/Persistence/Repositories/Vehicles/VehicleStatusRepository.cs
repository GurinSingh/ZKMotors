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
    internal class VehicleStatusRepository : IVehicleStatusRepository
    {
        private readonly ZKDbContext _context;
        public VehicleStatusRepository(ZKDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleStatus>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.VehicleStatuses.ToListAsync(cancellationToken);
        }

        public async Task<VehicleStatus> GetByIdAsync(int vehicleStatusId, CancellationToken cancellationToken)
        {
            return await _context.VehicleStatuses.FindAsync(vehicleStatusId, cancellationToken);
        }
    }
}
