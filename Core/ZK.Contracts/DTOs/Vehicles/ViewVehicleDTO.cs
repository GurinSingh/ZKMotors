using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleDTO
    {
        public ViewVehicleDTO()
        {
            this.Images = new List<ViewVehicleImageDTO>();
        }
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsSold { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public string Trim { get; set; }
        public string BodyType { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public string Drivetrain { get; set; }
        public int NumberOfOwners { get; set; }
        public int NumberOfDoors { get; set; }
        public int SeatingCapacity { get; set; }
        public string Features { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public List<ViewVehicleImageDTO> Images { get; set; }
    }
}
