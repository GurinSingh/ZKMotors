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
            builder.Property(v => v.StatusId).IsRequired();
            builder.Property(v => v.Price).HasPrecision(10, 2);
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

            builder.HasOne(v=> v.VehicleBasicIdentification)
                .WithOne(vbi => vbi.Vehicle)
                .HasForeignKey<VehicleBasicIdentification>(vbi => vbi.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.VehicleTechnicalSpecification)
                .WithOne(vts => vts.Vehicle)
                .HasForeignKey<VehicleTechnicalSpecification>(vts => vts.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
