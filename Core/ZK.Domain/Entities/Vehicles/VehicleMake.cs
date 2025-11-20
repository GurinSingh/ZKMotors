using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Entities.Vehicles
{
    public class VehicleMake
    {
        public VehicleMake()
        {
            this.VehicleBasicIdentifications = new HashSet<VehicleBasicIdentification>();
            this.VehicleModels = new HashSet<VehicleModel>();
        }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }

        public virtual ICollection<VehicleBasicIdentification> VehicleBasicIdentifications { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
