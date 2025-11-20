using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class VehicleStatusService : IVehicleStatusService
    {
        private readonly IRepositoryManager _repositoryManager;
        public VehicleStatusService(IRepositoryManager repositoryManager) 
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ViewVehicleStatusDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicleStatuses = await this._repositoryManager.VehicleStatusRepository.GetAllAsync(cancellationToken);
            return vehicleStatuses.Select(vs => vs.ToDTO());
        }

        public async Task<ViewVehicleStatusDTO> GetByIdAsync(int vehicleStatusId, CancellationToken cancellationToken)
        {
            var vehicleStatus = await this._repositoryManager.VehicleStatusRepository.GetByIdAsync(vehicleStatusId, cancellationToken);
            return vehicleStatus.ToDTO();
        }
    }
}
