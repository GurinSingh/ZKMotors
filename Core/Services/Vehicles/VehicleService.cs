using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Respositories;
using ZK.Domain.Utilities;
using ZK.Services.Abstractions.Vehicles;

namespace ZK.Services.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepositoryManager _repositoryManager;
        public VehicleService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }
        public async Task<ViewVehicleDTO> GetByIdAsync(int vehicleId, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetByIdAsync(vehicleId, cancellationToken);
            if (vehicle == null) 
                return null;
            return this._mapToDTO(vehicle);
        }
        public async Task<ViewVehicleDTO> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetBySlugAsync(slug, cancellationToken);
            if (vehicle == null)
                return null;
            return this._mapToDTO(vehicle);
        }
        public async Task<IEnumerable<ViewVehicleDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicles = await this._repositoryManager.VehicleRepository.GetAllAsync(cancellationToken);
            return vehicles.Select(v => this._mapToDTO(v));
        }
        public async Task<IEnumerable<ViewVehicleDTO>> GetAllIncludingSoldOutAsync(CancellationToken cancellationToken)
        {
            var vehicles = await this._repositoryManager.VehicleRepository.GetAllIncludingSoldOutAsync(cancellationToken);
            return vehicles.Select(v => this._mapToDTO(v));
        }
        public async Task AddAsync(AddVehicleDTO addVehicleDTO, CancellationToken cancellationToken)
        {
            var vehicle = this._mapToEntity(addVehicleDTO);

            vehicle.Make = this._repositoryManager.VehicleMakeRepository.GetByIdAsync(vehicle.MakeId, cancellationToken).Result;
            if(vehicle.Make == null)
                throw new Exception("Invalid MakeId");

            vehicle.Model = this._repositoryManager.VehicleModelRepository.GetByIdAsync(vehicle.ModelId, cancellationToken).Result;
            if (vehicle.Model == null)
                throw new Exception("Invalid ModelId");

            string slug = $"{vehicle.Year}-{vehicle.Make.Name}-{vehicle.Model.Name}";

            vehicle.Slug = UrlSlugger.GenerateSlug(slug);

            try
            {
                await this._repositoryManager.UnitOfWork.BeginTransactionAsync();

                await this._repositoryManager.VehicleRepository.AddAsync(vehicle, cancellationToken);
                await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                vehicle.Slug += $"-{vehicle.VehicleId}";

                await this._repositoryManager.VehicleRepository.UpdateAsync(vehicle, cancellationToken);
                await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                await this._repositoryManager.UnitOfWork.CommitTransactionAsync();
            }
            catch
            {
                await this._repositoryManager.UnitOfWork.RollbackTransactionAsync();
                throw;
            }
            
        }

        #region private methods
        private ViewVehicleDTO _mapToDTO(Vehicle vehicle)
        {
            return new ViewVehicleDTO
            {
                Id = vehicle.VehicleId,
                Make = vehicle.Make.Name,
                Model = vehicle.Model.Name,
                Year = vehicle.Year,
                Price = vehicle.Price,
                Color = vehicle.Color,
                Description = vehicle.Description
            };
        }
        private Vehicle _mapToEntity(AddVehicleDTO addVehicleDTO)
        {
            return new Vehicle
            {
                MakeId = addVehicleDTO.MakeId,
                ModelId = addVehicleDTO.ModelId,
                Year = addVehicleDTO.Year,
                Price = addVehicleDTO.Price,
                Color = addVehicleDTO.Color,
                Description = addVehicleDTO.Description,
                Sold = false
            };
        }
        #endregion

    }
}
