using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Sales;

namespace ZK.Domain.Entities.Vehicles
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Slug { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public bool IsSold { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }

        public virtual VehicleMake Make { get; set; }
        public virtual VehicleModel Model { get; set; }
        public virtual SaleHistory SaleHistory { get; set; }
    }
}
