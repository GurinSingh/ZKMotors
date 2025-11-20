using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IVehicleStatusService
    {
        Task<IEnumerable<ViewVehicleStatusDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<ViewVehicleStatusDTO> GetByIdAsync(int vehicleStatusId, CancellationToken cancellationToken);
    }
}
