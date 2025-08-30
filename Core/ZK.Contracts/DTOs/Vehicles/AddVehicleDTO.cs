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
        public bool IsSold { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }

        public List<AddVehicleImageDTO> Images { get; set; }
    }
}
