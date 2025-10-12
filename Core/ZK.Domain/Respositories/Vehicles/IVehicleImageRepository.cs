using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IVehicleImageRepository: IGetSingleByPredicateRepository<VehicleImage>, IGetManyByPredicateRespository<VehicleImage>
    {
        Task<IEnumerable<VehicleImage>> GetByVehicleIdAsync(int vehicleId, CancellationToken cancellationToken);
        Task DeleteAllbyVehicleIdAsync(int vehicleId, CancellationToken cancellationToken);
    }
}
