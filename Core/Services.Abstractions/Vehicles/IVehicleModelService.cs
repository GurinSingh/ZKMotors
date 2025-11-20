using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<ViewVehicleModelDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ViewVehicleModelDTO>> GetByMakeIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default);
    }
}
