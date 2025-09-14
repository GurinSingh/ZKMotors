using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Persistence.Configurations.Vehicles
{
    public sealed class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.VehicleId).IsClustered(true);
            builder.Property(v => v.Slug).IsRequired().HasMaxLength(45);
            builder.Property(v => v.MakeId).IsRequired();
            builder.Property(v => v.ModelId).IsRequired();
            builder.Property(v => v.Year).IsRequired();
            builder.Property(v => v.IsSold);
            builder.Property(v => v.ExteriorColor);
            builder.Property(v => v.InteriorColor);
            builder.Property(v => v.Mileage);
            builder.Property(v => v.Description).HasMaxLength(500);
            builder.Property(v => v.Price).HasPrecision(10, 2);
            builder.Property(v => v.VIN).HasMaxLength(17);
            builder.Property(v => v.Trim).HasMaxLength(50);
            builder.Property(v => v.BodyTypeId).IsRequired();
            builder.Property(v => v.EngineId);
            builder.Property(v => v.TransmissionId);
            builder.Property(v => v.FuelTypeId);
            builder.Property(v => v.DrivetrainId);
            builder.Property(v => v.NumberOfOwners);
            builder.Property(v => v.NumberOfDoors);
            builder.Property(v => v.SeatingCapacity);
            builder.Property(v => v.NumberOfDoors);
            builder.Property(v => v.Features).HasMaxLength(1000);
            builder.Property(v => v.AddedDateTime).IsRequired();
            builder.Property(v => v.LastUpdatedDateTime).IsRequired();

            builder.Property(v => v.VehicleId)
                .UseIdentityColumn(1,1);

            builder.HasIndex(v => v.Slug)
                .IsUnique();

            builder.HasOne(v => v.SaleHistory)
                .WithOne(sh => sh.Vehicle)
                .HasForeignKey<Domain.Entities.Sales.SaleHistory>(sh => sh.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.VehicleImages)
                .WithOne(vi => vi.Vehicle)
                .HasForeignKey(vi => vi.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
