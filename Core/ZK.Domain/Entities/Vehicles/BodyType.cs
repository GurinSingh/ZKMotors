using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Entities.Vehicles
{
    public class BodyType
    {
        public int BodyTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
