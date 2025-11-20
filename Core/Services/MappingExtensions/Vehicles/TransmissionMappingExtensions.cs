using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class TransmissionMappingExtensions
    {
        internal static ViewTransmissionDTO ToDTO(this Transmission transmission)
        {
            if (transmission == null) 
                return null;

            return new ViewTransmissionDTO
            {
                TransmissionId = transmission.TransmissionId,
                Name = transmission.Name,
                Description = transmission.Description,
            };
        }
    }
}
