using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class AddVehicleMakeDTO
    {
        public string Name { get; set; }
        public IFormFile ImageData { get; set; }
    }
}
