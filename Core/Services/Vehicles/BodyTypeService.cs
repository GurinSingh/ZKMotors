using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;

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
            return bodyTypes.Select(bt => this.MapToDTO(bt));
        }

        public async Task<ViewBodyTypeDTO> GetByIdAsync(int bodyTypeId, CancellationToken cancellationToken)
        {
            var bodyType = await this._repositoryManager.BodyTypeRepository.GetByIdAsync(bodyTypeId, cancellationToken);
            return this.MapToDTO(bodyType);
        }

        #region private methods
        private ViewBodyTypeDTO MapToDTO(BodyType bodyType)
        {
            return new ViewBodyTypeDTO
            {
                BodyTypeId = bodyType.BodyTypeId,
                Name = bodyType.Name,
                Description = bodyType.Description
            };
        }
        #endregion
    }
}
