using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Contracts.DTOs.Vehicles
{
    public class ViewVehicleTechnicalSpecificationDTO
    {
        public int VehicleTechnicalSpecificationId { get; set; }
        public int SeatingCapacity { get; set; }
        public int NumberOfOwners { get; set; }
        public int NumberOfDoors { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public int Kmpl_City { get; set; }
        public int Kmpl_Highway { get; set; }
        public int Kmpl_Combined { get; set; }

        public virtual ViewEngineDTO Engine { get; set; }
        public virtual ViewTransmissionDTO Transmission { get; set; }
        public virtual ViewFuelTypeDTO FuelType { get; set; }
        public virtual ViewDrivetrainDTO Drivetrain { get; set; }
    }

    public class AddVehicleTechnicalSpecificationDTO
    {
        public int SeatingCapacity { get; set; }
        public int NumberOfOwners { get; set; }
        public int NumberOfDoors { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public int Kmpl_City { get; set; }
        public int Kmpl_Highway { get; set; }
        public int Kmpl_Combined { get; set; }
        public int EngineId { get; set; }
        public int TransmissionId { get; set; }
        public int FuelTypeId { get; set; }
        public int DrivetrainId { get; set; }
    }
}
