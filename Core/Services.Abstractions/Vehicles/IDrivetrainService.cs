using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IDrivetrainService
    {
        Task<ViewDrivetrainDTO> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ViewDrivetrainDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
