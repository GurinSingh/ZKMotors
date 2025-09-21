using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IBodyTypeService
    {
        Task<IEnumerable<ViewBodyTypeDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<ViewBodyTypeDTO> GetByIdAsync(int bodyTypeId, CancellationToken cancellationToken);
    }
}
