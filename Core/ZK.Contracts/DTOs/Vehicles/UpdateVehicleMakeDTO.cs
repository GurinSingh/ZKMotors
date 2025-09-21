using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class UpdateVehicleMakeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageData { get; set; }
    }
}
