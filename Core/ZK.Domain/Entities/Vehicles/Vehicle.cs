﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Sales;

namespace ZK.Domain.Entities.Vehicles
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.VehicleImages = new HashSet<VehicleImage>();
        }
        public int VehicleId { get; set; }
        public string Slug { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public bool IsSold { get; set; }
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
        public DateTime AddedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        public virtual VehicleMake Make { get; set; }
        public virtual VehicleModel Model { get; set; }
        public virtual SaleHistory SaleHistory { get; set; }
        public virtual ICollection<VehicleImage> VehicleImages { get; set; }
        public virtual BodyType BodyType { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual Drivetrain Drivetrain { get; set; }
    }
}
