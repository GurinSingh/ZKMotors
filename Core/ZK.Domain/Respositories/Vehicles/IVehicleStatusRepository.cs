using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IVehicleStatusRepository
    {
        Task<VehicleStatus> GetByIdAsync(int vehicleStatusId, CancellationToken cancellationToken);
        Task<IEnumerable<VehicleStatus>> GetAllAsync(CancellationToken cancellationToken);
    }
}
