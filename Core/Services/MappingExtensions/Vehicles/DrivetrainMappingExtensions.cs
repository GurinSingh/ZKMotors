using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class DrivetrainMappingExtensions
    {
        internal static ViewDrivetrainDTO ToDTO(this Drivetrain drivetrain)
        {
            if (drivetrain == null)
                return null;
            
            return new ViewDrivetrainDTO
            {
                DrivetrainId = drivetrain.DrivetrainId,
                Name = drivetrain.Name,
                Description = drivetrain.Description
            };
        }
    }
}
