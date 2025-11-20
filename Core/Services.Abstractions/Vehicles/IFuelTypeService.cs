using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Vehicles;

namespace ZK.Services.Abstractions.Vehicles
{
    public interface IFuelTypeService
    {
        Task<ViewFuelTypeDTO> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ViewFuelTypeDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
