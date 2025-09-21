using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Services.Abstractions.Vehicles;

namespace ZK.Services.Abstractions
{
    public interface IServiceManager
    {
        IVehicleService VehicleService { get; }
        IVehicleMakeService VehicleMakeService { get; }
    }
}
