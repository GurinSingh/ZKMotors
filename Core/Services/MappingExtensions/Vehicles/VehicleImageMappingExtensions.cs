using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;
using ZK.Domain.Utilities;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class VehicleImageMappingExtensions
    {
        internal static VehicleImage ToEntity(this AddVehicleImageDTO addVehicleImageDTO)
        {
            if (addVehicleImageDTO == null)
                return null;
            
            return new VehicleImage
            {
                ImageData = ImageHelper.ConvertToByteArray(addVehicleImageDTO.Image),
                ContentType = addVehicleImageDTO.ContentType,
                FileName = addVehicleImageDTO.FileName
            };
        }
        internal static ViewVehicleImageDTO ToDTO(this VehicleImage vehicleImage)
        {
            if (vehicleImage == null)
                return null;

            return new ViewVehicleImageDTO
            {
                VehicleImageId = vehicleImage.VehicleImageId,
                VehicleId = vehicleImage.VehicleId,
                ImageBase64 = Convert.ToBase64String(vehicleImage.ImageData),
                ContentType = vehicleImage.ContentType,
                FileName = vehicleImage.FileName,
                AddedDateTime = vehicleImage.AddedDateTime
            };
        }
    }
}
