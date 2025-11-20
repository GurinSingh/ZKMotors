using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Dashboard;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Sales;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Enums;
using ZK.Domain.Respositories;
using ZK.Domain.Utilities;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

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
            return vehicle.ToDTO();
        }
        public async Task<ViewVehicleDTO> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetAsync(v => v.Slug == slug, cancellationToken);
            if (vehicle == null)
                return null;
            return vehicle.ToDTO();
        }
        public async Task<IEnumerable<ViewVehicleDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var vehicles = await this._repositoryManager.VehicleRepository.GetAllAsync(cancellationToken);
            return vehicles.Select(v => v.ToDTO());
        }
        public async Task AddAsync(AddVehicleDTO addVehicleDTO, CancellationToken cancellationToken)
        {
            var vehicle = addVehicleDTO.ToEntity();

            vehicle.VehicleBasicIdentification.Make = await this._repositoryManager.VehicleMakeRepository.GetByIdAsync(vehicle.VehicleBasicIdentification.MakeId, cancellationToken);
            if (vehicle.VehicleBasicIdentification.Make == null)
                throw new Exception("Invalid MakeId");

            vehicle.VehicleBasicIdentification.Model = await this._repositoryManager.VehicleModelRepository.GetByIdAsync(vehicle.VehicleBasicIdentification.ModelId, cancellationToken);
            if (vehicle.VehicleBasicIdentification.Model == null)
                throw new Exception("Invalid ModelId");

            string slug = $"{vehicle.VehicleBasicIdentification.Make.Name}-{vehicle.VehicleBasicIdentification.Model.Name}";

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
            if (vehicle.StatusId == (int)eVehicleStatus.Sold)
                throw new Exception("Vehicle is already marked as sold");
            vehicle.StatusId = (int)eVehicleStatus.Sold;
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
            var relatedVehicles = await this._repositoryManager.VehicleRepository.GetManyAsync(v => v.VehicleBasicIdentification.BodyTypeId == vehicle.VehicleBasicIdentification.BodyTypeId && v.VehicleId != vehicle.VehicleId, cancellationToken);
            return relatedVehicles.Take(5).Select(v => v.ToDTO());
        }
        public async Task UpdateAsync(UpdateVehicleDTO updateVehicleDTO, CancellationToken cancellationToken)
        {
            var vehicle = await this._repositoryManager.VehicleRepository.GetByIdAsync(updateVehicleDTO.VehicleId, cancellationToken);
            if (vehicle == null)
                throw new Exception("Vehicle not found");

            vehicle.Price = updateVehicleDTO.Price;
            vehicle.LastUpdatedDateTime = DateTime.UtcNow;

            vehicle.VehicleBasicIdentification = new VehicleBasicIdentification
            {
                ModelId = updateVehicleDTO.ModelId,
                MakeId = updateVehicleDTO.MakeId,
                Year = updateVehicleDTO.Year,
                ExteriorColor = updateVehicleDTO.ExteriorColor,
                InteriorColor = updateVehicleDTO.InteriorColor,
                Description = updateVehicleDTO.Description,
                Mileage = updateVehicleDTO.Mileage,
                VIN = updateVehicleDTO.VIN,
                Trim = updateVehicleDTO.Trim,
                BodyTypeId = updateVehicleDTO.BodyTypeId,
                Features = updateVehicleDTO.Features
            };

            vehicle.VehicleTechnicalSpecification = new VehicleTechnicalSpecification
            {
                EngineId = updateVehicleDTO.EngineId,
                TransmissionId = updateVehicleDTO.TransmissionId,
                FuelTypeId = updateVehicleDTO.FuelTypeId,
                DrivetrainId = updateVehicleDTO.DrivetrainId,
                NumberOfOwners = updateVehicleDTO.NumberOfOwners,
                NumberOfDoors = updateVehicleDTO.NumberOfDoors,
                SeatingCapacity = updateVehicleDTO.SeatingCapacity,
            };

            vehicle.VehicleBasicIdentification.Make = await this._repositoryManager.VehicleMakeRepository.GetByIdAsync(vehicle.VehicleBasicIdentification.MakeId, cancellationToken);
            if (vehicle.VehicleBasicIdentification.Make == null)
                throw new Exception("Invalid MakeId");

            vehicle.VehicleBasicIdentification.Model = await this._repositoryManager.VehicleModelRepository.GetByIdAsync(vehicle.VehicleBasicIdentification.ModelId, cancellationToken);
            if (vehicle.VehicleBasicIdentification.Model == null)
                throw new Exception("Invalid ModelId");

            //delete existing images
            await this._repositoryManager.VehicleImageRepository.DeleteAllbyVehicleIdAsync(vehicle.VehicleId, cancellationToken);

            if (updateVehicleDTO.Images != null && updateVehicleDTO.Images.Count > 0)
            {
                vehicle.VehicleImages = updateVehicleDTO.Images.Select(i => new VehicleImage
                {
                    VehicleId = updateVehicleDTO.VehicleId,
                    ImageData = ImageHelper.ConvertToByteArray(i.Image),
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
                .GetAsync(v => v.VehicleBasicIdentification.MakeId == vehicleMakeId && v.VehicleBasicIdentification.ModelId == vehicleModelId
                    && ((year != 0 && v.VehicleBasicIdentification.Year == year) || year == 0)
                    && ((!string.IsNullOrEmpty(trim) && v.VehicleBasicIdentification.Trim.ToLower() == trim.ToLower()) || string.IsNullOrEmpty(trim)), cancellationToken);
            if (vehicle == null)
                return null;
            return vehicle.ToDTO();
        }
        public async Task<DashboardStatsDTO> GetDashboardStats(CancellationToken cancellationToken)
        {
            var allVehicles = await this._repositoryManager.VehicleRepository.GetAllAsync(cancellationToken);
            return new DashboardStatsDTO
            {
                OnSale = allVehicles.Count(v => v.StatusId == (int)eVehicleStatus.OnSale),
                Sold = allVehicles.Count(v => v.StatusId == (int)eVehicleStatus.Sold),
                OnHold = allVehicles.Count(v => v.StatusId == (int)eVehicleStatus.OnHold),
                TotalRevenue = await this._repositoryManager.SaleHistoryRepository.GetTotalRevenueAsync(cancellationToken)
            };
        }
        public async Task<IEnumerable<ViewVehicleStatusDTO>> GetAllVehicleStatusesAsync(CancellationToken cancellationToken)
        {
            var statuses = await this._repositoryManager.VehicleStatusRepository.GetAllAsync(cancellationToken);
            return statuses.Select(s => new ViewVehicleStatusDTO
            {
                VehicleStatusId = s.VehicleStatusId,
                Name = s.Name,
                Description = s.Description
            });
        }
    }
}
