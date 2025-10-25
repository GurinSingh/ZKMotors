using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class VehicleCount
    {
        public int OnSale { get; set; }
        public int Sold { get; set; }
        public int onHold { get; set; }
    }
}
