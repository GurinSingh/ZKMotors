﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Entities.Vehicles
{
    public class VehicleModel
    {
        public VehicleModel()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
        public int VehicleModelId { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual VehicleMake Make { get; set;}
    }
}
