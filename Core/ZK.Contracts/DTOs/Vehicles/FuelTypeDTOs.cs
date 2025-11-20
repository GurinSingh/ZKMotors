using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewFuelTypeDTO
    {
        public int FuelTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
