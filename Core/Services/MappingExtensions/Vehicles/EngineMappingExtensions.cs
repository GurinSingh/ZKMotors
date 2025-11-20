using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Services.MappingExtensions.Vehicles
{
    internal static class EngineMappingExtensions
    {
        internal static ViewEngineDTO ToDTO(this Engine engine)
        {
            if (engine == null) return null;
            return new ViewEngineDTO
            {
                EngineId = engine.EngineId,
                Name = engine.Name,
                Description = engine.Description,
            };
        }
    }
}
