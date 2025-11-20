using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public BodyTypeService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ViewBodyTypeDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var bodyTypes = await this._repositoryManager.BodyTypeRepository.GetAllAsync(cancellationToken);
            return bodyTypes.Select(bt => bt.ToDTO());
        }

        public async Task<ViewBodyTypeDTO> GetByIdAsync(int bodyTypeId, CancellationToken cancellationToken)
        {
            var bodyType = await this._repositoryManager.BodyTypeRepository.GetByIdAsync(bodyTypeId, cancellationToken);
            return bodyType.ToDTO();
        }
    }
}
