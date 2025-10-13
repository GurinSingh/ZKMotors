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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IRepositoryManager _repositoryManager;
        public VehicleModelService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ViewVehicleModelDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var vehicles = await this._repositoryManager.VehicleModelRepository.GetAllAsync(cancellationToken);
            return vehicles.Select(vm => MapToDTO(vm));
        }

        public async Task<IEnumerable<ViewVehicleModelDTO>> GetByMakeIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default)
        {
            var vehicles = await this._repositoryManager.VehicleModelRepository.GetByMakeIdAsync(vehicleMakeId, cancellationToken);
            return vehicles.Select(vm => MapToDTO(vm));
        }

        #region private methods
        private ViewVehicleModelDTO MapToDTO(VehicleModel vehicleModel)
        {
            if (vehicleModel == null)
                return null;

            return new ViewVehicleModelDTO
            {
                VehicleModelId = vehicleModel.VehicleModelId,
                Name = vehicleModel.Name,
                MakeId = vehicleModel.MakeId
            };
        }
        #endregion
    }
}
