using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleBasicIdentificationDTO
    {
        public int VehicleBasicIdentificationId { get; set; }
        public int Year { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Description { get; set; }
        public string VIN { get; set; }
        public string Trim { get; set; }
        public string Features { get; set; }
        public int Mileage { get; set; }

        public virtual ViewBodyTypeDTO BodyType { get; set; }
        public virtual ViewVehicleMakeDTO Make { get; set; }
        public virtual ViewVehicleModelDTO Model { get; set; }
    }

    public class AddVehicleBasicIdentificationDTO
    {
        public int Year { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Description { get; set; }
        public string VIN { get; set; }
        public string Trim { get; set; }
        public string Features { get; set; }
        public int Mileage { get; set; }
        public int BodyTypeId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
    }
}
