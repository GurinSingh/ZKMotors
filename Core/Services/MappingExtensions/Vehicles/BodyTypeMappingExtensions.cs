using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class BodyTypeMappingExtensions
    {
        internal static ViewBodyTypeDTO ToDTO(this BodyType bodyType)
        {
            if (bodyType == null) 
                return null;

            return new ViewBodyTypeDTO
            {
                BodyTypeId = bodyType.BodyTypeId,
                Name = bodyType.Name,
                Description = bodyType.Description
            };
        }
    }
}
