using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Entities.Vehicles
{
    public class VehicleImage
    {
        public int VehicleImageId { get; set; }
        public int VehicleId { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
