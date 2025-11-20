using System.ComponentModel;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleDTO
    {
        public ViewVehicleDTO()
        {
            this.Images = new List<ViewVehicleImageDTO>();
        }

        public int VehicleId { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public virtual List<ViewVehicleImageDTO> Images { get; set; }
        public virtual ViewVehicleStatusDTO VehicleStatus { get; set; }
        public virtual ViewVehicleBasicIdentificationDTO BasicIdentification { get; set; }
        public virtual ViewVehicleTechnicalSpecificationDTO TechnicalSpecification { get; set; }
    }

    public class AddVehicleDTO
    {
        public AddVehicleDTO()
        {
            this.Images = new List<AddVehicleImageDTO>();
        }

        public decimal Price { get; set; }
        public int StatusId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public virtual AddVehicleBasicIdentificationDTO BasicIdentification { get; set; }
        public virtual AddVehicleTechnicalSpecificationDTO TechnicalSpecification { get; set; }
        public List<AddVehicleImageDTO> Images { get; set; }
    }

    public class UpdateVehicleDTO
    {
        public UpdateVehicleDTO()
        {
            this.Images = new List<UpdateVehicleImageDTO>();
        }
        public int VehicleId { get; set; }
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

        public List<UpdateVehicleImageDTO> Images { get; set; }
    }
}
