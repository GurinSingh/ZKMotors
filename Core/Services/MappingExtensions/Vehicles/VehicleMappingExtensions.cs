using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;
using ZK.Services.MappingExtensions.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class VehicleMappingExtensions
    {
        internal static Vehicle ToEntity(this AddVehicleDTO vehicle)
        {
            if (vehicle == null)
                return null;

            return new Vehicle
            {
                Price = vehicle.Price,
                AddedDateTime = vehicle.AddedDateTime,
                LastUpdatedDateTime = vehicle.LastUpdatedDateTime,

                StatusId = vehicle.StatusId,
                VehicleImages = vehicle.Images.Select(i => i.ToEntity()).ToList(),
                VehicleBasicIdentification = vehicle.BasicIdentification.ToEntity(),
                VehicleTechnicalSpecification = vehicle.TechnicalSpecification.ToEntity()
            };
        }
        internal static VehicleBasicIdentification ToEntity(this AddVehicleBasicIdentificationDTO vehicleBasicIdentification)
        {
            if (vehicleBasicIdentification == null)
                return null;

            return new VehicleBasicIdentification
            {
                MakeId = vehicleBasicIdentification.MakeId,
                ModelId = vehicleBasicIdentification.ModelId,
                BodyTypeId = vehicleBasicIdentification.BodyTypeId,
                Year = vehicleBasicIdentification.Year,
                ExteriorColor = vehicleBasicIdentification.ExteriorColor,
                InteriorColor = vehicleBasicIdentification.InteriorColor,
                Description = vehicleBasicIdentification.Description,
                VIN = vehicleBasicIdentification.VIN,
                Trim = vehicleBasicIdentification.Trim,
                Features = vehicleBasicIdentification.Features,
                Mileage = vehicleBasicIdentification.Mileage
            };
        }
        internal static VehicleTechnicalSpecification ToEntity(this AddVehicleTechnicalSpecificationDTO vehicleTechnicalSpecification)
        {
            if (vehicleTechnicalSpecification == null)
                return null;

            return new VehicleTechnicalSpecification
            {
                EngineId = vehicleTechnicalSpecification.EngineId,
                TransmissionId = vehicleTechnicalSpecification.TransmissionId,
                FuelTypeId = vehicleTechnicalSpecification.FuelTypeId,
                DrivetrainId = vehicleTechnicalSpecification.DrivetrainId,
                Horsepower = vehicleTechnicalSpecification.Horsepower,
                Torque = vehicleTechnicalSpecification.Torque,
                Kmpl_City = vehicleTechnicalSpecification.Kmpl_City,
                Kmpl_Highway = vehicleTechnicalSpecification.Kmpl_Highway,
                Kmpl_Combined = vehicleTechnicalSpecification.Kmpl_Combined
            };
        }
        internal static ViewVehicleDTO ToDTO(this Vehicle vehicle)
        {
            if (vehicle == null)
                return null;
            return new ViewVehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                Slug = vehicle.Slug,
                Price = vehicle.Price,
                AddedDateTime = vehicle.AddedDateTime,
                LastUpdatedDateTime = vehicle.LastUpdatedDateTime,
                VehicleStatus = vehicle.VehicleStatus.ToDTO(),
                Images = vehicle.VehicleImages.Select(vi => vi.ToDTO()).ToList(),
                BasicIdentification = vehicle.VehicleBasicIdentification.ToDTO(),
                TechnicalSpecification = vehicle.VehicleTechnicalSpecification.ToDTO()
            };
        }
        
        internal static ViewVehicleBasicIdentificationDTO ToDTO(this VehicleBasicIdentification vehicleBasicIdentification)
        {
            if (vehicleBasicIdentification == null)
                return null;

            return new ViewVehicleBasicIdentificationDTO
            {
                Make = vehicleBasicIdentification.Make.ToDTO(),
                Model = vehicleBasicIdentification.Model.ToDTO(),
                BodyType = vehicleBasicIdentification.BodyType.ToDTO(),
                Year = vehicleBasicIdentification.Year,
                ExteriorColor = vehicleBasicIdentification.ExteriorColor,
                InteriorColor = vehicleBasicIdentification.InteriorColor,
                Description = vehicleBasicIdentification.Description,
                VIN = vehicleBasicIdentification.VIN,
                Trim = vehicleBasicIdentification.Trim,
                Features = vehicleBasicIdentification.Features,
                Mileage = vehicleBasicIdentification.Mileage
            };
        }
        internal static ViewVehicleTechnicalSpecificationDTO ToDTO(this VehicleTechnicalSpecification vehicleTechnicalSpecification)
        {
            if (vehicleTechnicalSpecification == null)
                return null;
            return new ViewVehicleTechnicalSpecificationDTO
            {
                Engine = vehicleTechnicalSpecification.Engine.ToDTO(),
                Transmission = vehicleTechnicalSpecification.Transmission.ToDTO(),
                FuelType = vehicleTechnicalSpecification.FuelType.ToDTO(),
                Drivetrain = vehicleTechnicalSpecification.Drivetrain.ToDTO(),
                Horsepower = vehicleTechnicalSpecification.Horsepower,
                Torque = vehicleTechnicalSpecification.Torque,
                Kmpl_City = vehicleTechnicalSpecification.Kmpl_City,
                Kmpl_Highway = vehicleTechnicalSpecification.Kmpl_Highway,
                Kmpl_Combined = vehicleTechnicalSpecification.Kmpl_Combined
            };
        }
    }
}
