using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class AddVehicleDTO
    {
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public bool IsSold { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
    }
}
