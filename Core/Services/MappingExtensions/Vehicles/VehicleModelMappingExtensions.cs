using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class VehicleModelMappingExtensions
    {
        internal static ViewVehicleModelDTO ToDTO(this VehicleModel vehicleModel)
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
    }
}
