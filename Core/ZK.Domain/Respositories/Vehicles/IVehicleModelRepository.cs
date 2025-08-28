using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IVehicleModelRepository
    {
        Task<VehicleModel> GetByIdAsync(int vehicleModelId, CancellationToken cancellationToken = default);
        Task<IEnumerable<VehicleModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(VehicleModel vehicleModel, CancellationToken cancellationToken = default);
    }
}
