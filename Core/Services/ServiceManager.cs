using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Respositories;
using ZK.Services.Abstractions;
using ZK.Services.Abstractions.Account;
using ZK.Services.Abstractions.Users;
using ZK.Services.Abstractions.Vehicles;
using ZK.Services.Authentication;
using ZK.Services.Vehicles;
using ZK.Services.Users;
using ZK.Domain.Entities.Users;

namespace ZK.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IVehicleService> _lazyVehicleService;
        private readonly Lazy<IVehicleMakeService> _lazyVehicleMakeService;
        private readonly Lazy<IBodyTypeService> _lazyBodyTypeService;
        private readonly Lazy<IAuthenticationService> _lazyAuthenticationService;
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IVehicleModelService> _lazyVehicleModelService;
        private readonly Lazy<IVehicleStatusService> _lazyVehicleStatusService;
        private readonly Lazy<IFuelTypeService> _lazyFuelTypeService;
        private readonly Lazy<ITransmissionService> _lazyTransmissionService;
        private readonly Lazy<IDrivetrainService> _lazyDrivetrainService;

        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, SignInManager<User> signInManager)
        {
            this._lazyVehicleService = new Lazy<IVehicleService>(() => new VehicleService(repositoryManager));
            this._lazyVehicleMakeService = new Lazy<IVehicleMakeService>(() => new VehicleMakeService(repositoryManager));
            this._lazyBodyTypeService = new Lazy<IBodyTypeService>(() => new BodyTypeService(repositoryManager));
            this._lazyAuthenticationService = new Lazy<IAuthenticationService>(()=> new AuthenticationService(repositoryManager, configuration, signInManager));
            this._lazyUserService = new Lazy<IUserService>(()=> new UserService(repositoryManager));
            this._lazyVehicleModelService = new Lazy<IVehicleModelService>(()=> new VehicleModelService(repositoryManager));
            this._lazyVehicleStatusService = new Lazy<IVehicleStatusService>(() => new VehicleStatusService(repositoryManager));
            this._lazyFuelTypeService = new Lazy<IFuelTypeService>(() => new FuelTypeService(repositoryManager));
            this._lazyTransmissionService = new Lazy<ITransmissionService>(() => new TransmissionService(repositoryManager));
            this._lazyDrivetrainService = new Lazy<IDrivetrainService>(() => new DrivetrainService(repositoryManager));
        }

        public IVehicleService VehicleService => _lazyVehicleService.Value;
        public IVehicleMakeService VehicleMakeService => _lazyVehicleMakeService.Value;
        public IBodyTypeService BodyTypeService => _lazyBodyTypeService.Value;
        public IAuthenticationService AuthenticationService => _lazyAuthenticationService.Value;
        public IUserService UserService => _lazyUserService.Value;
        public IVehicleModelService VehicleModelService => _lazyVehicleModelService.Value;
        public IVehicleStatusService VehicleStatusService => _lazyVehicleStatusService.Value;
        public IFuelTypeService FuelTypeService => _lazyFuelTypeService.Value;
        public ITransmissionService TransmissionService => _lazyTransmissionService.Value;
        public IDrivetrainService DrivetrainService => _lazyDrivetrainService.Value;
    }
}
