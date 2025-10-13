using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleMakeDTO
    {
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
    }
}
