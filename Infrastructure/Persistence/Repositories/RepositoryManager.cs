using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories;
using ZK.Domain.Respositories.Sales;
using ZK.Domain.Respositories.Vehicles;
using ZK.Persistence.Repositories.Sales;
using ZK.Persistence.Repositories.Vehicles;

namespace ZK.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IVehicleRepository> _lazyVehicleRepository;
        private readonly Lazy<IVehicleMakeRepository> _lazyVehicleMakeRepository;
        private readonly Lazy<IVehicleModelRepository> _lazyVehicleModelRepository;
        private readonly Lazy<ISaleHistoryRepository> _lazySaleHistoryRepository;
        private readonly Lazy<IBodyTypeRepository> _lazyBodyTypeRepository;
        private readonly Lazy<VehicleImageRepository> _lazyVehicleImageRepository;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ZKDbContext context)
        {
            this._lazyVehicleRepository = new Lazy<IVehicleRepository>(() => new VehicleRepository(context));
            this._lazyVehicleMakeRepository = new Lazy<IVehicleMakeRepository>(() => new VehicleMakeRepository(context));
            this._lazyVehicleModelRepository = new Lazy<IVehicleModelRepository>(() => new VehicleModelRepository(context));
            this._lazySaleHistoryRepository = new Lazy<ISaleHistoryRepository>(() => new SaleHistoryRepository(context));
            this._lazyBodyTypeRepository = new Lazy<IBodyTypeRepository>(() => new BodyTypeRepository(context));
            this._lazyVehicleImageRepository = new Lazy<VehicleImageRepository>(() => new VehicleImageRepository(context));

            this._lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IVehicleRepository VehicleRepository => this._lazyVehicleRepository.Value;
        public IVehicleMakeRepository VehicleMakeRepository => this._lazyVehicleMakeRepository.Value;
        public IVehicleModelRepository VehicleModelRepository => this._lazyVehicleModelRepository.Value;
        public ISaleHistoryRepository SaleHistoryRepository => this._lazySaleHistoryRepository.Value;
        public IBodyTypeRepository BodyTypeRepository => this._lazyBodyTypeRepository.Value;
        public IVehicleImageRepository VehicleImageRepository => this._lazyVehicleImageRepository.Value;

        public IUnitOfWork UnitOfWork => this._lazyUnitOfWork.Value;
    }
}
