using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Entities.Vehicles
{
    public class VehicleModel
    {
        public VehicleModel()
        {
            this.VehicleBasicIdentifications = new HashSet<VehicleBasicIdentification>();
        }
        public int VehicleModelId { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VehicleBasicIdentification> VehicleBasicIdentifications { get; set; }
        public virtual VehicleMake Make { get; set;}
    }
}
