using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IVehicleMakeService
    {
        Task<ViewVehicleMakeDTO> GetByIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ViewVehicleMakeDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(AddVehicleMakeDTO addVehicleMakeDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(UpdateVehicleMakeDTO updateVehicleMakeDto , CancellationToken cancellationToken = default);
    }
}
