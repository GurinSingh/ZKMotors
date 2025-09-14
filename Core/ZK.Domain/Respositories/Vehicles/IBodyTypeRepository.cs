using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IBodyTypeRepository
    {
        Task<IEnumerable<BodyType>> GetAllAsync(CancellationToken cancellationToken);
        Task<BodyType> GetByIdAsync(int bodyTypeId, CancellationToken cancellationToken);
    }
}
