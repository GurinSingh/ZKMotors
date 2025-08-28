using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IVehicleMakeRepository
    {
        Task<VehicleMake> GetByIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<VehicleMake>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(VehicleMake vehicleMake, CancellationToken cancellationToken = default);
    }
}
