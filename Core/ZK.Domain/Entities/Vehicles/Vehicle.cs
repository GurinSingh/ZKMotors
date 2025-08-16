using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Entities.Vehicles
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Make = new();
            this.Model = new();
        }
        public int VehicleId { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }
        public int Year { get; set; }

        public virtual VehicleMake Make { get; set; }
        public virtual VehicleModel Model { get; set; }
    }
}
