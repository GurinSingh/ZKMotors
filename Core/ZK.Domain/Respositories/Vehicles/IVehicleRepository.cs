using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Domain.Respositories.Vehicles
{
    public interface IVehicleRepository: IGetSingleByPredicateRepository<Vehicle>, IGetManyByPredicateRespository<Vehicle>
    {
        Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
        Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken);
        Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken);
        Task<Vehicle> GetByIdAsync(int vehicleId, CancellationToken cancellationToken);
    }
}
