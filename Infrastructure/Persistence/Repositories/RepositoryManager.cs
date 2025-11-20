using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Users;
using ZK.Domain.Respositories;
using ZK.Domain.Respositories.Account;
using ZK.Domain.Respositories.Sales;
using ZK.Domain.Respositories.Vehicles;
using ZK.Persistence.Identity;
using ZK.Persistence.Repositories.Account;
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
        private readonly Lazy<IVehicleImageRepository> _lazyVehicleImageRepository;
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IRoleRepository> _lazyRoleRepository;
        private readonly Lazy<IRoleClaimRepository> _lazyRoleClaimRepository;
        private readonly Lazy<IUserRoleRepository> _lazyUserRoleRepository;
        private readonly Lazy<IVehicleStatusRepository> _lazyVehicleStatusRepository;
        private readonly Lazy<IFuelTypeRepository> _lazyFuelTypeRepository;
        private readonly Lazy<ITransmissionRepository> _lazyTransmissionRepository;
        private readonly Lazy<IDrivetrainRepository> _lazyDrivetrainRepository;

        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ZKDbContext context)
        {
            this._lazyVehicleRepository = new Lazy<IVehicleRepository>(() => new VehicleRepository(context));
            this._lazyVehicleMakeRepository = new Lazy<IVehicleMakeRepository>(() => new VehicleMakeRepository(context));
            this._lazyVehicleModelRepository = new Lazy<IVehicleModelRepository>(() => new VehicleModelRepository(context));
            this._lazySaleHistoryRepository = new Lazy<ISaleHistoryRepository>(() => new SaleHistoryRepository(context));
            this._lazyBodyTypeRepository = new Lazy<IBodyTypeRepository>(() => new BodyTypeRepository(context));
            this._lazyVehicleImageRepository = new Lazy<IVehicleImageRepository>(() => new VehicleImageRepository(context));
            this._lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            this._lazyRoleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(context));
            this._lazyRoleClaimRepository = new Lazy<IRoleClaimRepository>(() => new RoleClaimRepository(context));
            this._lazyUserRoleRepository = new Lazy<IUserRoleRepository>(() => new UserRoleRepository(context));
            this._lazyVehicleStatusRepository = new Lazy<IVehicleStatusRepository>(() => new VehicleStatusRepository(context));
            this._lazyFuelTypeRepository = new Lazy<IFuelTypeRepository>(() => new FuelTypeRepository(context));
            this._lazyTransmissionRepository = new Lazy<ITransmissionRepository>(() => new TransmissionRepository(context));
            this._lazyDrivetrainRepository = new Lazy<IDrivetrainRepository>(() => new DrivetrainRepository(context));

            this._lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IVehicleRepository VehicleRepository => this._lazyVehicleRepository.Value;
        public IVehicleMakeRepository VehicleMakeRepository => this._lazyVehicleMakeRepository.Value;
        public IVehicleModelRepository VehicleModelRepository => this._lazyVehicleModelRepository.Value;
        public ISaleHistoryRepository SaleHistoryRepository => this._lazySaleHistoryRepository.Value;
        public IBodyTypeRepository BodyTypeRepository => this._lazyBodyTypeRepository.Value;
        public IVehicleImageRepository VehicleImageRepository => this._lazyVehicleImageRepository.Value;
        public IUserRepository UserRepository => this._lazyUserRepository.Value;
        public IRoleRepository RoleRepository => this._lazyRoleRepository.Value;
        public IRoleClaimRepository RoleClaimRepository => this._lazyRoleClaimRepository.Value;
        public IUserRoleRepository UserRoleRepository => this._lazyUserRoleRepository.Value;
        public IVehicleStatusRepository VehicleStatusRepository => this._lazyVehicleStatusRepository.Value;
        public IFuelTypeRepository FuelTypeRepository => this._lazyFuelTypeRepository.Value;
        public ITransmissionRepository TransmissionRepository => this._lazyTransmissionRepository.Value;
        public IDrivetrainRepository DrivetrainRepository => this._lazyDrivetrainRepository.Value;

        public IUnitOfWork UnitOfWork => this._lazyUnitOfWork.Value;
    }
}
