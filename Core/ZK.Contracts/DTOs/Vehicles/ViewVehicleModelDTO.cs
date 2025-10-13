using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleModelDTO
    {
        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }
    }
}
