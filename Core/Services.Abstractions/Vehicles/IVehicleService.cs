using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IVehicleService
    {
        Task AddAsync(AddVehicleDTO addVehicleDTO, CancellationToken cancellationToken);
        //Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken);
        Task<IEnumerable<ViewVehicleDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<ViewVehicleDTO>> GetAllIncludingSoldOutAsync(CancellationToken cancellationToken);
        Task<ViewVehicleDTO> GetByIdAsync(int vehicleId, CancellationToken cancellationToken);
        //Task<IEnumerable<Vehicle>> GetByMakeAsync(int makeId, CancellationToken cancellationToken);
        //Task<IEnumerable<Vehicle>> GetByModelAsync(int modelId, CancellationToken cancellationToken);
        Task<ViewVehicleDTO> GetBySlugAsync(string slug, CancellationToken cancellationToken);
        Task MarkAsSold(int vehicleId, CancellationToken cancellationToken);
    }
}
