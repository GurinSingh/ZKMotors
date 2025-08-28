using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories;
using ZK.Domain.Respositories.Vehicles;
using ZK.Persistence.Repositories.Vehicles;

namespace ZK.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IVehicleRepository> _lazyVehicleRepository;
        private readonly Lazy<IVehicleMakeRepository> _lazyVehicleMakeRepository;
        private readonly Lazy<IVehicleModelRepository> _lazyVehicleModelRepository;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ZKDbContext context)
        {
            this._lazyVehicleRepository = new Lazy<IVehicleRepository>(() => new VehicleRepository(context));
            this._lazyVehicleMakeRepository = new Lazy<IVehicleMakeRepository>(() => new VehicleMakeRepository(context));
            this._lazyVehicleModelRepository = new Lazy<IVehicleModelRepository>(() => new VehicleModelRepository(context));

            this._lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IVehicleRepository VehicleRepository => this._lazyVehicleRepository.Value;
        public IVehicleMakeRepository VehicleMakeRepository => this._lazyVehicleMakeRepository.Value;
        public IVehicleModelRepository VehicleModelRepository => this._lazyVehicleModelRepository.Value;

        public IUnitOfWork UnitOfWork => this._lazyUnitOfWork.Value;
    }
}
