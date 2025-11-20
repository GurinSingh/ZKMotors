using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class VehicleStatusMappingExtensions
    {
        internal static ViewVehicleStatusDTO ToDTO(this VehicleStatus vehicleStatus)
        {
            if (vehicleStatus == null) 
                return null;

            return new ViewVehicleStatusDTO
            {
                VehicleStatusId = vehicleStatus.VehicleStatusId,
                Name = vehicleStatus.Name,
                Description = vehicleStatus.Description
            };
        }

        internal static VehicleStatus ToEntity(this ViewVehicleStatusDTO vehicleStatusDTO)
        {
            if (vehicleStatusDTO == null) 
                return null;

            return new VehicleStatus
            {
                VehicleStatusId = vehicleStatusDTO.VehicleStatusId,
                Name = vehicleStatusDTO.Name,
                Description = vehicleStatusDTO.Description
            };
        }
    }
}
