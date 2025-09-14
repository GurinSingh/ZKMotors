using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class UpdateVehicleImageDTO
    {
        public int VehicleId { get; set; }
        public IFormFile ImageData { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
