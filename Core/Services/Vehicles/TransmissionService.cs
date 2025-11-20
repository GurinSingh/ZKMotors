using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class TransmissionService : ITransmissionService
    {
        private readonly IRepositoryManager _repositoryManager;
        public TransmissionService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ViewTransmissionDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var transmissions = await this._repositoryManager.TransmissionRepository.GetAllAsync(cancellationToken);
            return transmissions.Select(t => t.ToDTO());
        }

        public async Task<ViewTransmissionDTO> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var transmission = await this._repositoryManager.TransmissionRepository.GetByIdAsync(id, cancellationToken);
            return transmission.ToDTO();
        }
    }
}
