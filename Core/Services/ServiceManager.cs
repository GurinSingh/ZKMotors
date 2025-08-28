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

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            this._lazyVehicleService = new Lazy<IVehicleService>(() => new VehicleService(repositoryManager));
        }

        public IVehicleService VehicleService => _lazyVehicleService.Value;
    }
}
