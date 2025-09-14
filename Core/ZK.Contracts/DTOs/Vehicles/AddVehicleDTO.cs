using Microsoft.AspNetCore.Http;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class AddVehicleDTO
    {
        public AddVehicleDTO()
        {
            this.Images = new List<AddVehicleImageDTO>();
        }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public string Trim { get; set; }
        public int BodyTypeId { get; set; }
        public int EngineId { get; set; }
        public int TransmissionId { get; set; }
        public int FuelTypeId { get; set; }
        public int DrivetrainId { get; set; }
        public int NumberOfOwners { get; set; }
        public int NumberOfDoors { get; set; }
        public int SeatingCapacity { get; set; }
        public string Features { get; set; }

        public List<AddVehicleImageDTO> Images { get; set; }
    }
}
