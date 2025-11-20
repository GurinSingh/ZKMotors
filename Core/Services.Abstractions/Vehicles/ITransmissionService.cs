using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface ITransmissionService
    {
        Task<ViewTransmissionDTO> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ViewTransmissionDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
