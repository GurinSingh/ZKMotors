using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.Vehicles;

namespace ZK.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IVehicleService> _lazyVehicleService;
        private readonly Lazy<IVehicleMakeService> _lazyVehicleMakeService;
        private readonly Lazy<IBodyTypeService> _lazyBodyTypeService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            this._lazyVehicleService = new Lazy<IVehicleService>(() => new VehicleService(repositoryManager));
            this._lazyVehicleMakeService = new Lazy<IVehicleMakeService>(() => new VehicleMakeService(repositoryManager));
            this._lazyBodyTypeService = new Lazy<IBodyTypeService>(() => new BodyTypeService(repositoryManager));
        }

        public IVehicleService VehicleService => _lazyVehicleService.Value;
        public IVehicleMakeService VehicleMakeService => _lazyVehicleMakeService.Value;
        public IBodyTypeService BodyTypeService => _lazyBodyTypeService.Value;
    }
}
