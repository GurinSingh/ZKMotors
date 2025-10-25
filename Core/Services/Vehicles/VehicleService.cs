using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Sales;
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
            return this.MapToDTO(vehicle);
        }
        public async Task<ViewVehicleDTO> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetAsync(v=> v.Slug == slug, cancellationToken);
            if (vehicle == null)
                return null;
            return this.MapToDTO(vehicle);
        }
        public async Task<IEnumerable<ViewVehicleDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicles = await this._repositoryManager.VehicleRepository.GetAllAsync(cancellationToken);
            return vehicles.Select(v => this.MapToDTO(v));
        }
        public async Task AddAsync(AddVehicleDTO addVehicleDTO, CancellationToken cancellationToken)
        {
            var vehicle = this.MapToEntity(addVehicleDTO);

            vehicle.Make = await this._repositoryManager.VehicleMakeRepository.GetByIdAsync(vehicle.MakeId, cancellationToken);
            if (vehicle.Make == null)
                throw new Exception("Invalid MakeId");

            vehicle.Model = await this._repositoryManager.VehicleModelRepository.GetByIdAsync(vehicle.ModelId, cancellationToken);
            if (vehicle.Model == null)
                throw new Exception("Invalid ModelId");

            string slug = $"{vehicle.Make.Name}-{vehicle.Model.Name}";

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
        public async Task MarkAsSold(int vehicleId, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetByIdAsync(vehicleId, cancellationToken);
            if (vehicle == null)
                throw new Exception("Vehicle not found");
            if (vehicle.IsSold)
                throw new Exception("Vehicle is already marked as sold");
            vehicle.IsSold = true;
            await this._repositoryManager.VehicleRepository.UpdateAsync(vehicle, cancellationToken);

            //Adding entry to SaleHistory
            var saleHistory = new SaleHistory
            {
                VehicleId = vehicle.VehicleId,
                SaleDateTime = DateTime.UtcNow,
                SalePrice = vehicle.Price,
                CustomerName = "N/A",
                CustomerPhoneNo = "N/A",
                Notes = "Marked as sold without customer details",
            };
            await this._repositoryManager.SaleHistoryRepository.AddAsync(saleHistory, cancellationToken);

            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<ViewVehicleDTO>> GetRelatedVehicleById(int vehicleId, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetByIdAsync(vehicleId, cancellationToken);
            if (vehicle == null)
                throw new Exception("Vehicle not found");
            var relatedVehicles = await this._repositoryManager.VehicleRepository.GetManyAsync(v=> v.BodyTypeId == vehicle.BodyTypeId && v.VehicleId != vehicle.VehicleId, cancellationToken);
            return relatedVehicles.Take(5).Select(v => this.MapToDTO(v));
        }
        public async Task UpdateAsync(UpdateVehicleDTO updateVehicleDTO, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetByIdAsync(updateVehicleDTO.Id, cancellationToken);
            if (vehicle == null)
                throw new Exception("Vehicle not found");

            vehicle.ModelId = updateVehicleDTO.ModelId;
            vehicle.MakeId = updateVehicleDTO.MakeId;
            vehicle.Year = updateVehicleDTO.Year;
            vehicle.Price = updateVehicleDTO.Price;
            vehicle.ExteriorColor = updateVehicleDTO.ExteriorColor;
            vehicle.InteriorColor = updateVehicleDTO.InteriorColor;
            vehicle.Description = updateVehicleDTO.Description;
            vehicle.Mileage = updateVehicleDTO.Mileage;
            vehicle.VIN = updateVehicleDTO.VIN;
            vehicle.Trim = updateVehicleDTO.Trim;
            vehicle.BodyTypeId = updateVehicleDTO.BodyTypeId;
            vehicle.EngineId = updateVehicleDTO.EngineId;
            vehicle.TransmissionId = updateVehicleDTO.TransmissionId;
            vehicle.FuelTypeId = updateVehicleDTO.FuelTypeId;
            vehicle.DrivetrainId = updateVehicleDTO.DrivetrainId;
            vehicle.NumberOfOwners = updateVehicleDTO.NumberOfOwners;
            vehicle.NumberOfDoors = updateVehicleDTO.NumberOfDoors;
            vehicle.SeatingCapacity = updateVehicleDTO.SeatingCapacity;
            vehicle.Features = updateVehicleDTO.Features;
            vehicle.LastUpdatedDateTime = DateTime.UtcNow;

            vehicle.Make = await this._repositoryManager.VehicleMakeRepository.GetByIdAsync(vehicle.MakeId, cancellationToken);
            if (vehicle.Make == null)
                throw new Exception("Invalid MakeId");

            vehicle.Model = await this._repositoryManager.VehicleModelRepository.GetByIdAsync(vehicle.ModelId, cancellationToken);
            if (vehicle.Model == null)
                throw new Exception("Invalid ModelId");

            //delete existing images
            await this._repositoryManager.VehicleImageRepository.DeleteAllbyVehicleIdAsync(vehicle.VehicleId, cancellationToken);
            
            if (updateVehicleDTO.Images != null && updateVehicleDTO.Images.Count > 0)
            {
                vehicle.VehicleImages = updateVehicleDTO.Images.Select(i => new VehicleImage
                {
                    VehicleId = i.VehicleId,
                    ImageData = ImageHelper.ConvertToByteArray(i.ImageData),
                    ContentType = i.ContentType,
                    FileName = i.FileName,
                    AddedDateTime = DateTime.UtcNow
                }).ToList();
            }

            await this._repositoryManager.VehicleRepository.UpdateAsync(vehicle, cancellationToken);
            await this._repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task<ViewVehicleDTO> GetVehicleInformation(int vehicleMakeId, int vehicleModelId, int year, string trim, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository
                .GetAsync(v => v.MakeId == vehicleMakeId && v.ModelId == vehicleModelId
                    && ((year !=0 && v.Year == year) || year == 0)
                    && ((!string.IsNullOrEmpty(trim) && v.Trim.ToLower() == trim.ToLower()) || string.IsNullOrEmpty(trim)), cancellationToken);
            if (vehicle == null)
                return null;
            return this.MapToDTO(vehicle);
        }
        public async Task<VehicleCount> GetVehicleCount(CancellationToken cancellationToken)
        {
            var allVehicles = await this._repositoryManager.VehicleRepository.GetAllAsync(cancellationToken);
            return new VehicleCount
            {
                OnSale = allVehicles.Count(v=> !v.IsSold),
                Sold = allVehicles.Count(v => v.IsSold),
                onHold = 0,
            };
        }

        #region private methods
        private ViewVehicleDTO MapToDTO(Vehicle vehicle)
        {
            return new ViewVehicleDTO
            {
                Id = vehicle.VehicleId,
                Slug = vehicle.Slug,
                Model = vehicle.Model.Name,
                Make = vehicle.Make.Name,
                Year = vehicle.Year,
                IsSold = vehicle.IsSold,
                ExteriorColor = vehicle.ExteriorColor,
                InteriorColor = vehicle.InteriorColor,
                Description = vehicle.Description,
                Price = vehicle.Price,
                Mileage = vehicle.Mileage,
                VIN = vehicle.VIN,
                Trim = vehicle.Trim,
                BodyType = vehicle.BodyType.Name,
                Engine = vehicle.Engine.Name,
                Transmission = vehicle.Transmission.Name,
                FuelType = vehicle.FuelType.Name,
                Drivetrain = vehicle.Drivetrain.Name,
                NumberOfOwners = vehicle.NumberOfOwners,
                NumberOfDoors = vehicle.NumberOfDoors,
                SeatingCapacity = vehicle.SeatingCapacity,
                Features = vehicle.Features,
                AddedDateTime = vehicle.AddedDateTime,
                LastUpdatedDateTime = vehicle.LastUpdatedDateTime,

                Images = vehicle.VehicleImages.Select(vi => new ViewVehicleImageDTO
                {
                    ContentType = vi.ContentType,
                    FileName = vi.FileName,
                    ImageBase64 = Convert.ToBase64String(vi.ImageData),
                    AddedDateTime = vi.AddedDateTime
                }).OrderByDescending(v => v.AddedDateTime).ToList()
            };
        }
        private Vehicle MapToEntity(AddVehicleDTO addVehicleDTO)
        {
            return new Vehicle
            {
                MakeId = addVehicleDTO.MakeId,
                ModelId = addVehicleDTO.ModelId,
                Year = addVehicleDTO.Year,
                Price = addVehicleDTO.Price,
                ExteriorColor = addVehicleDTO.ExteriorColor,
                InteriorColor = addVehicleDTO.InteriorColor,
                Description = addVehicleDTO.Description,
                IsSold = false,
                Mileage = addVehicleDTO.Mileage,
                VIN = addVehicleDTO.VIN,
                Trim = addVehicleDTO.Trim,
                BodyTypeId = addVehicleDTO.BodyTypeId,
                EngineId = addVehicleDTO.EngineId,
                TransmissionId = addVehicleDTO.TransmissionId,
                FuelTypeId = addVehicleDTO.FuelTypeId,
                DrivetrainId = addVehicleDTO.DrivetrainId,
                NumberOfOwners = addVehicleDTO.NumberOfOwners,
                NumberOfDoors = addVehicleDTO.NumberOfDoors,
                SeatingCapacity = addVehicleDTO.SeatingCapacity,
                Features = addVehicleDTO.Features,
                AddedDateTime = DateTime.UtcNow,
                LastUpdatedDateTime = DateTime.UtcNow,

                VehicleImages = addVehicleDTO.Images.Select(i => new VehicleImage
                {
                    VehicleId = i.VehicleId,
                    ImageData = ImageHelper.ConvertToByteArray(i.ImageData),
                    ContentType = i.ContentType,
                    FileName = i.FileName,
                    AddedDateTime = DateTime.UtcNow
                }).ToList()
            };
        }
        #endregion
    }
}
