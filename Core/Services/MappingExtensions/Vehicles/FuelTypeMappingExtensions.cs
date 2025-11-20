using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class FuelTypeMappingExtensions
    {
        internal static ViewFuelTypeDTO ToDTO(this FuelType fuelType)
        {
            if (fuelType == null)
                return null;

            return new ViewFuelTypeDTO
            {
                FuelTypeId = fuelType.FuelTypeId,
                Name = fuelType.Name,
                Description = fuelType.Description
            };
        }
    }
}
