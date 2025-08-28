using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Persistence
{
    public class ZKDbContext : DbContext
    {
        public ZKDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZKDbContext).Assembly);

            // Seed VehicleMakes
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { VehicleMakeId = 1, Name = "Toyota" },
                new VehicleMake { VehicleMakeId = 2, Name = "Ford" },
                new VehicleMake { VehicleMakeId = 3, Name = "Honda" },
                new VehicleMake { VehicleMakeId = 4, Name = "Chevrolet" }
            );

            // Seed VehicleModels
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { VehicleModelId = 1, Name = "Camry", MakeId = 1, Make = null },
                new VehicleModel { VehicleModelId = 2, Name = "Corolla", MakeId = 1, Make = null },
                new VehicleModel { VehicleModelId = 3, Name = "RAV4", MakeId = 1, Make = null },
                new VehicleModel { VehicleModelId = 4, Name = "F-150", MakeId = 2, Make = null },
                new VehicleModel { VehicleModelId = 5, Name = "Mustang", MakeId = 2, Make = null },
                new VehicleModel { VehicleModelId = 6, Name = "Civic", MakeId = 3, Make = null },
                new VehicleModel { VehicleModelId = 7, Name = "Accord", MakeId = 3, Make = null },
                new VehicleModel { VehicleModelId = 8, Name = "Silverado", MakeId = 4, Make = null },
                new VehicleModel { VehicleModelId = 9, Name = "Malibu", MakeId = 4, Make = null }
            );

            // Seed Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    VehicleId = 1,
                    Slug = "camry-2025-1",
                    MakeId = 1,
                    ModelId = 1,
                    Year = 2025,
                    Sold = false,
                    Color = "White",
                    Description = "2025 Toyota Camry in white color",
                    Price = 25000.00m,

                    Make = null,
                    Model = null
                },
                new Vehicle
                {
                    VehicleId = 2,
                    Slug = "corolla-2024-2",
                    MakeId = 1,
                    ModelId = 2,
                    Year = 2024,
                    Sold = true,
                    Color = "Blue",
                    Description = "2024 Toyota Corolla in blue color",
                    Price = 20000.00m,

                    Make = null,
                    Model = null
                },
                new Vehicle
                {
                    VehicleId = 3,
                    Slug = "focus-2023-3",
                    MakeId = 2,
                    ModelId = 4,
                    Year = 2023,
                    Sold = false,
                    Color = "Red",
                    Description = "2023 Ford Focus in red",
                    Price = 22000.00m,

                    Make = null,
                    Model = null
                },
                new Vehicle
                {
                    VehicleId = 4,
                    Slug = "mustang-2024-4",
                    MakeId = 2,
                    ModelId = 5,
                    Year = 2024,
                    Sold = false,
                    Color = "Black",
                    Description = "2024 Ford Mustang GT",
                    Price = 35000.00m,

                    Make = null,
                    Model = null
                },
                new Vehicle
                {
                    VehicleId = 5,
                    Slug = "civic-2023-5",
                    MakeId = 3,
                    ModelId = 6,
                    Year = 2023,
                    Sold = true,
                    Color = "Gray",
                    Description = "2023 Honda Civic in gray color",
                    Price = 21000.00m,

                    Make = null,
                    Model = null
                }
            );
        }
    }
}
