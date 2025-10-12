using Microsoft.EntityFrameworkCore;
using ZK.Domain.Entities.Users;
using ZK.Domain.Entities.Sales;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Persistence
{
    public class ZKDbContext : DbContext
    {
        public ZKDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Drivetrain> Drivetrains { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZKDbContext).Assembly);

            // Seed VehicleMakes
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { VehicleMakeId = 1, Name = "Toyota", ImageData = [] },
                new VehicleMake { VehicleMakeId = 2, Name = "Ford", ImageData = [] },
                new VehicleMake { VehicleMakeId = 3, Name = "Honda", ImageData = [] },
                new VehicleMake { VehicleMakeId = 4, Name = "Chevrolet", ImageData = [] }
            );

            // Seed VehicleModels
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { VehicleModelId = 1, Name = "Camry", MakeId = 1 },
                new VehicleModel { VehicleModelId = 2, Name = "Corolla", MakeId = 1 },
                new VehicleModel { VehicleModelId = 3, Name = "RAV4", MakeId = 1 },
                new VehicleModel { VehicleModelId = 4, Name = "F-150", MakeId = 2 },
                new VehicleModel { VehicleModelId = 5, Name = "Mustang", MakeId = 2 },
                new VehicleModel { VehicleModelId = 6, Name = "Civic", MakeId = 3 },
                new VehicleModel { VehicleModelId = 7, Name = "Accord", MakeId = 3 },
                new VehicleModel { VehicleModelId = 8, Name = "Silverado", MakeId = 4 },
                new VehicleModel { VehicleModelId = 9, Name = "Malibu", MakeId = 4 }
            );

            // Seed Engine table with Description
            modelBuilder.Entity<Engine>().HasData(
                new Engine { EngineId = 1, Name = "2.5L Inline 4 Cylinder", Description = "Reliable 2.5 liter inline 4-cylinder engine, suitable for everyday driving." },
                new Engine { EngineId = 2, Name = "3.5L V6", Description = "Powerful 3.5 liter V6 engine for enhanced performance." },
                new Engine { EngineId = 3, Name = "2.0L Turbo Inline 4", Description = "Turbocharged 2.0 liter inline 4-cylinder engine with improved acceleration." },
                new Engine { EngineId = 4, Name = "5.3L V8", Description = "Large 5.3 liter V8 engine, commonly used in trucks and SUVs for towing." },
                new Engine { EngineId = 5, Name = "5.0L V8", Description = "High-performance 5.0 liter V8 engine for sports vehicles." },
                new Engine { EngineId = 6, Name = "1.5L Turbo Inline 4", Description = "Fuel-efficient 1.5 liter turbocharged inline 4-cylinder engine." }
            );

            // Seed Transmission table with Description
            modelBuilder.Entity<Transmission>().HasData(
                new Transmission { TransmissionId = 1, Name = "Manual", Description = "Requires driver to manually change gears using clutch and gear lever." },
                new Transmission { TransmissionId = 2, Name = "Automatic", Description = "Automatically changes gears without driver input for convenience." },
                new Transmission { TransmissionId = 3, Name = "Continuously Variable Transmission (CVT)", Description = "Delivers smooth acceleration with a seamless range of gear ratios." },
                new Transmission { TransmissionId = 4, Name = "Dual-Clutch Automatic", Description = "Offers quick, efficient gear changes with two separate clutches." },
                new Transmission { TransmissionId = 5, Name = "Automated Manual (AMT)", Description = "A manual transmission with automated clutch and gear shifts." }
            );

            // Seed FuelType table with Description
            modelBuilder.Entity<FuelType>().HasData(
                new FuelType { FuelTypeId = 1, Name = "Gasoline", Description = "Standard gasoline fuel used in most combustion engines." },
                new FuelType { FuelTypeId = 2, Name = "Diesel", Description = "Diesel fuel offering higher efficiency and torque for heavy-duty vehicles." },
                new FuelType { FuelTypeId = 3, Name = "Hybrid", Description = "Combination of gasoline engine and electric motor for improved fuel economy." },
                new FuelType { FuelTypeId = 4, Name = "Electric", Description = "Fully electric powertrain using battery stored energy." }
            );

            // Seed BodyType table with Description
            modelBuilder.Entity<BodyType>().HasData(
                new BodyType { BodyTypeId = 1, Name = "Sedan", Description = "A passenger car in a three-box configuration with separate compartments for engine, passenger, and cargo." },
                new BodyType { BodyTypeId = 2, Name = "Pickup Truck", Description = "Vehicle with an open cargo area and passenger cab, used for hauling." },
                new BodyType { BodyTypeId = 3, Name = "SUV", Description = "Sport Utility Vehicle combining off-road capability with passenger comfort." },
                new BodyType { BodyTypeId = 4, Name = "Coupe", Description = "A two-door car with a fixed roof and sporty design." },
                new BodyType { BodyTypeId = 5, Name = "Hatchback", Description = "Compact car with a rear door that swings upward to provide access to cargo area." },
                new BodyType { BodyTypeId = 6, Name = "Convertible", Description = "Car with a roof structure that can be 'converted' to allow open-air or enclosed driving." },
                new BodyType { BodyTypeId = 7, Name = "Minivan", Description = "A van designed for personal use, especially for families." },
                new BodyType { BodyTypeId = 8, Name = "Station Wagon", Description = "A car with an extended rear cargo area, accessed via a rear door or hatch." },
                new BodyType { BodyTypeId = 9, Name = "Van", Description = "A larger vehicle used for transporting goods or groups of people." },
                new BodyType { BodyTypeId = 10, Name = "Crossover", Description = "Vehicle built on a car platform combining features of a hatchback and SUV." }
            );

            // Seed Drivetrain table with Description
            modelBuilder.Entity<Drivetrain>().HasData(
                new Drivetrain { DrivetrainId = 1, Name = "Front-Wheel Drive (FWD)", Description = "Power delivered to the front wheels, typical for fuel-efficient vehicles." },
                new Drivetrain { DrivetrainId = 2, Name = "Rear-Wheel Drive (RWD)", Description = "Power delivered to the rear wheels, preferred for performance and towing." },
                new Drivetrain { DrivetrainId = 3, Name = "All-Wheel Drive (AWD)", Description = "Power automatically distributed to all wheels for better traction." },
                new Drivetrain { DrivetrainId = 4, Name = "Four-Wheel Drive (4WD)", Description = "Driver-selectable power distributed to all four wheels, for off-road driving." }
            );


            // Seed Vehicles
            //modelBuilder.Entity<Vehicle>().HasData(
            //    new Vehicle
            //    {
            //        VehicleId = 1,
            //        Slug = "toyota-camry-2022-se",
            //        MakeId = 1,
            //        ModelId = 1,
            //        Year = 2022,
            //        IsSold = false,
            //        ExteriorColor = "White",
            //        InteriorColor = "Black",
            //        Description = "Reliable midsize sedan with advanced safety features",
            //        Price = 24999.99m,
            //        Mileage = 15000,
            //        VIN = "JT123456789012345",
            //        Trim = "SE",
            //        BodyTypeId = 1,        // e.g. Sedan
            //        EngineId = 1,          // e.g. 2.5L I4
            //        TransmissionId = 2,    // e.g. Automatic
            //        FuelTypeId = 1,        // e.g. Gasoline
            //        DrivetrainId = 1,      // e.g. FWD
            //        NumberOfOwners = 1,
            //        NumberOfDoors = 4,
            //        SeatingCapacity = 5,
            //        Features = "Backup Camera, Bluetooth, Lane Departure Warning",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    },
            //    new Vehicle
            //    {
            //        VehicleId = 2,
            //        Slug = "ford-f150-2019-xl",
            //        MakeId = 2,
            //        ModelId = 4,
            //        Year = 2019,
            //        IsSold = true,
            //        ExteriorColor = "Blue",
            //        InteriorColor = "Gray",
            //        Description = "Powerful pickup truck with towing package",
            //        Price = 35999.99m,
            //        Mileage = 40000,
            //        VIN = "1FTFW1EF1KFB12345",
            //        Trim = "XL",
            //        BodyTypeId = 2,        // e.g. Pickup
            //        EngineId = 2,          // e.g. 3.5L V6
            //        TransmissionId = 2,
            //        FuelTypeId = 2,        // e.g. Diesel
            //        DrivetrainId = 2,      // e.g. 4WD
            //        NumberOfOwners = 2,
            //        NumberOfDoors = 2,
            //        SeatingCapacity = 3,
            //        Features = "Tow Package, Bluetooth, Rear Parking Sensors",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    },
            //    new Vehicle
            //    {
            //        VehicleId = 3,
            //        Slug = "honda-civic-2020-ex",
            //        MakeId = 3,
            //        ModelId = 6,
            //        Year = 2020,
            //        IsSold = false,
            //        ExteriorColor = "Red",
            //        InteriorColor = "Beige",
            //        Description = "Compact car with sporty handling",
            //        Price = 19999.99m,
            //        Mileage = 12000,
            //        VIN = "2HGFC2F59LH123456",
            //        Trim = "EX",
            //        BodyTypeId = 1,
            //        EngineId = 3,          // e.g. 2.0L I4 Turbo
            //        TransmissionId = 3,    // e.g. CVT
            //        FuelTypeId = 1,
            //        DrivetrainId = 1,
            //        NumberOfOwners = 1,
            //        NumberOfDoors = 4,
            //        SeatingCapacity = 5,
            //        Features = "Sunroof, Apple CarPlay, Heated Seats",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    },
            //    new Vehicle
            //    {
            //        VehicleId = 4,
            //        Slug = "chevrolet-silverado-2018-lt",
            //        MakeId = 4,
            //        ModelId = 8,
            //        Year = 2018,
            //        IsSold = true,
            //        ExteriorColor = "Black",
            //        InteriorColor = "Gray",
            //        Description = "Full-size pickup with off-road capability",
            //        Price = 28999.99m,
            //        Mileage = 55000,
            //        VIN = "3GCUKREC7JG123456",
            //        Trim = "LT",
            //        BodyTypeId = 2,
            //        EngineId = 4,          // e.g. 5.3L V8
            //        TransmissionId = 2,
            //        FuelTypeId = 1,
            //        DrivetrainId = 2,
            //        NumberOfOwners = 2,
            //        NumberOfDoors = 4,
            //        SeatingCapacity = 5,
            //        Features = "4WD, Navigation, Bluetooth",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    },
            //    new Vehicle
            //    {
            //        VehicleId = 5,
            //        Slug = "toyota-rav4-2021-xle",
            //        MakeId = 1,
            //        ModelId = 3,
            //        Year = 2021,
            //        IsSold = false,
            //        ExteriorColor = "Silver",
            //        InteriorColor = "Black",
            //        Description = "Compact SUV with fuel efficiency",
            //        Price = 30500.00m,
            //        Mileage = 8000,
            //        VIN = "JTMRWRFV0MD123456",
            //        Trim = "XLE",
            //        BodyTypeId = 3,        // SUV
            //        EngineId = 1,
            //        TransmissionId = 2,
            //        FuelTypeId = 1,
            //        DrivetrainId = 1,
            //        NumberOfOwners = 1,
            //        NumberOfDoors = 4,
            //        SeatingCapacity = 5,
            //        Features = "Blind Spot Monitor, Apple CarPlay, Heated Seats",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    },
            //    new Vehicle
            //    {
            //        VehicleId = 6,
            //        Slug = "ford-mustang-2017-gt",
            //        MakeId = 2,
            //        ModelId = 5,
            //        Year = 2017,
            //        IsSold = true,
            //        ExteriorColor = "Red",
            //        InteriorColor = "Black",
            //        Description = "Performance coupe with V8 engine",
            //        Price = 27999.99m,
            //        Mileage = 30000,
            //        VIN = "1FA6P8CF3H1234567",
            //        Trim = "GT",
            //        BodyTypeId = 1,
            //        EngineId = 5,          // e.g. 5.0L V8
            //        TransmissionId = 1,    // Manual
            //        FuelTypeId = 1,
            //        DrivetrainId = 1,
            //        NumberOfOwners = 1,
            //        NumberOfDoors = 2,
            //        SeatingCapacity = 4,
            //        Features = "Leather Seats, Performance Package, Bluetooth",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    },
            //    new Vehicle
            //    {
            //        VehicleId = 7,
            //        Slug = "honda-accord-2019-sport",
            //        MakeId = 3,
            //        ModelId = 7,
            //        Year = 2019,
            //        IsSold = false,
            //        ExteriorColor = "Gray",
            //        InteriorColor = "Black",
            //        Description = "Midsize sedan with sporty design",
            //        Price = 21999.99m,
            //        Mileage = 25000,
            //        VIN = "1HGCV1F39KA123456",
            //        Trim = "Sport",
            //        BodyTypeId = 1,
            //        EngineId = 3,
            //        TransmissionId = 3,
            //        FuelTypeId = 1,
            //        DrivetrainId = 1,
            //        NumberOfOwners = 1,
            //        NumberOfDoors = 4,
            //        SeatingCapacity = 5,
            //        Features = "Apple CarPlay, Remote Start, Sunroof",
            //        AddedDateTime = DateTime.UtcNow,
            //        LastUpdatedDateTime = DateTime.UtcNow
            //    }
            //);
        }
    }
}
