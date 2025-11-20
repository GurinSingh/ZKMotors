using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

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
            return vehicles.Select(vm => vm.ToDTO());
        }

        public async Task<IEnumerable<ViewVehicleModelDTO>> GetByMakeIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default)
        {
            var vehicles = await this._repositoryManager.VehicleModelRepository.GetByMakeIdAsync(vehicleMakeId, cancellationToken);
            return vehicles.Select(vm => vm.ToDTO());
        }

       
    }
}
