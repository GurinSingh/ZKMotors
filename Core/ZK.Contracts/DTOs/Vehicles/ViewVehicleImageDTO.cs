using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleImageDTO
    {
        public string ImageBase64 { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
