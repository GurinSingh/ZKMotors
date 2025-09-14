using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories.Sales;
using ZK.Domain.Respositories.Vehicles;

namespace ZK.Domain.Respositories
{
    public interface IRepositoryManager
    {
        IVehicleRepository VehicleRepository { get; }
        IVehicleMakeRepository VehicleMakeRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        ISaleHistoryRepository SaleHistoryRepository { get; }
        IBodyTypeRepository BodyTypeRepository { get; }
        IVehicleImageRepository VehicleImageRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
