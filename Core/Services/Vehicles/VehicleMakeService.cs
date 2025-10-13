using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories;
using ZK.Domain.Respositories.Vehicles;
using ZK.Domain.Utilities;
using ZK.Services.Abstractions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public VehicleMakeService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task AddAsync(AddVehicleMakeDTO addVehicleMakeDto, CancellationToken cancellationToken = default)
        {
            await this._repositoryManager.VehicleMakeRepository.AddAsync(new VehicleMake
            {
                Name = addVehicleMakeDto.Name,
                ImageData = ImageHelper.ConvertToByteArray(addVehicleMakeDto.ImageData)
            }, cancellationToken);

            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ViewVehicleMakeDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var vehicleMakes = await this._repositoryManager.VehicleMakeRepository.GetAllAsync(cancellationToken);
            return vehicleMakes.Select(vm=> this.MapToDTO(vm)).ToList();
        }

        public async Task<ViewVehicleMakeDTO> GetByIdAsync(int vehicleMakeId, CancellationToken cancellationToken = default)
        {
            var vehicleMake = await this._repositoryManager.VehicleMakeRepository.GetByIdAsync(vehicleMakeId, cancellationToken);
            return this.MapToDTO(vehicleMake);
        }

        public async Task UpdateAsync(UpdateVehicleMakeDTO updateVehicleMakeDTO, CancellationToken cancellationToken)
        {
            var vehicleMake = await this._repositoryManager.VehicleMakeRepository.GetByIdAsync(updateVehicleMakeDTO.Id, cancellationToken);
            if (vehicleMake == null)
                throw new Exception("Vehicle Make not found");

            vehicleMake.Name = updateVehicleMakeDTO.Name;
            vehicleMake.ImageData = ImageHelper.ConvertToByteArray(updateVehicleMakeDTO.ImageData);

            await this._repositoryManager.VehicleMakeRepository.UpdateAsync(vehicleMake);

            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        #region private methods
        private ViewVehicleMakeDTO MapToDTO(VehicleMake vehicleMake)
        {
            if (vehicleMake == null) 
                return null;

            return new ViewVehicleMakeDTO
            {
                VehicleMakeId = vehicleMake.VehicleMakeId,
                Name = vehicleMake.Name,
                ImageBase64 = vehicleMake.ImageData != null ? Convert.ToBase64String(vehicleMake.ImageData) : null
            };
        }
        private VehicleMake MapToEntity(AddVehicleMakeDTO addVehicleMakeDto)
        {
            return new VehicleMake
            {
                Name = addVehicleMakeDto.Name,
                ImageData = ImageHelper.ConvertToByteArray(addVehicleMakeDto.ImageData)
            };
        }
        #endregion
    }
}
