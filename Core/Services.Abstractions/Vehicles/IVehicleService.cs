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
        Task UpdateAsync(UpdateVehicleDTO vehicle, CancellationToken cancellationToken);
        Task<IEnumerable<ViewVehicleDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<ViewVehicleDTO> GetByIdAsync(int vehicleId, CancellationToken cancellationToken);
        Task<ViewVehicleDTO> GetBySlugAsync(string slug, CancellationToken cancellationToken);
        Task MarkAsSold(int vehicleId, CancellationToken cancellationToken);
        Task<IEnumerable<ViewVehicleDTO>> GetRelatedVehicleById(int vehicleId, CancellationToken cancellationToken);
        Task<ViewVehicleDTO> GetVehicleInformation(int vehicleMakeId, int vehicleModelId, int year, string trim, CancellationToken cancellationToken);
        Task<VehicleCount> GetVehicleCount(CancellationToken cancellationToken);
    }
}
