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

        public DbSet<Vehicle> Vehiles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZKDbContext).Assembly);

//            modelBuilder.Entity<VehicleMake>().HasData(
//                new VehicleMake { VehicleMakeId = 1, Name = "Toyota" },
//                new VehicleMake { VehicleMakeId = 2, Name = "Honda" },
//                new VehicleMake { VehicleMakeId = 3, Name = "Ford" }
//            );
//            modelBuilder.Entity<VehicleModel>().HasData(
//    new VehicleModel
//    {
//        VehicleModelId = 1,
//        Name = "Corolla",
//        MakeId = 1        // Set the foreign key value ONLY
//    },
//    new VehicleModel
//    {
//        VehicleModelId = 2,
//        Name = "Civic",
//        MakeId = 2
//    }
//);

            //modelBuilder.Entity<Vehicle>().HasData(
            //    new Vehicle { VehicleId = 1, MakeId = 1, ModelId = 1, Year = 2020, Color = "Red", Price = 27000, Slug = "corolla", Sold = true, Description = "This is toyota corolla" },
            //    new Vehicle { VehicleId = 2, MakeId = 2, ModelId = 2, Year = 2019, Color = "Green", Price = 18000, Slug = "civic", Sold = false, Description = "This is honda civic" },
            //    new Vehicle { VehicleId = 3, MakeId = 3, ModelId = 3, Year = 2021, Color = "Blue", Price = 21000, Slug = "mustang", Sold = false, Description = "This is ford mustang" }
            //);
        }
    }
}
