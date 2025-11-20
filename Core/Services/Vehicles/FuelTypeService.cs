using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public FuelTypeService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ViewFuelTypeDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var fuelTypes =  await this._repositoryManager.FuelTypeRepository.GetAllAsync(cancellationToken);
            return fuelTypes.Select(ft => ft.ToDTO());
        }

        public async Task<ViewFuelTypeDTO> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var fuelType = await this._repositoryManager.FuelTypeRepository.GetByIdAsync(id, cancellationToken);
            return fuelType.ToDTO();
        }
    }
}
