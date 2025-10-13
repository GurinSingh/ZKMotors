using ZK.Services.Abstractions.Account;
using ZK.Services.Abstractions.Users;
using ZK.Services.Abstractions.Vehicles;

namespace ZK.Services.Abstractions
{
    public interface IServiceManager
    {
        IVehicleService VehicleService { get; }
        IVehicleMakeService VehicleMakeService { get; }
        IBodyTypeService BodyTypeService { get; }
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IVehicleModelService VehicleModelService { get; }
    }
}
