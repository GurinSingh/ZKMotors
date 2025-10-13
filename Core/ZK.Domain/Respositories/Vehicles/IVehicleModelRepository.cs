using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IVehicleModelRepository: IBaseRepository<VehicleModel>
    {
        Task<IEnumerable<VehicleModel>> GetByMakeIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default);
    }
}
