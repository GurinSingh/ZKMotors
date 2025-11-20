using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class VehicleMakeMappingExtensions
    {
        internal static ViewVehicleMakeDTO ToDTO(this VehicleMake vehicleMake)
        {             
            if (vehicleMake == null) 
                return null;

            return new ViewVehicleMakeDTO
            {
                VehicleMakeId = vehicleMake.VehicleMakeId,
                Name = vehicleMake.Name,
                ImageBase64 = Convert.ToBase64String(vehicleMake.ImageData)
            };
        }
    }
}
