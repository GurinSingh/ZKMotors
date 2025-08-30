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
            builder.Property(v => v.Color);
            builder.Property(v => v.Mileage);
            builder.Property(v => v.Description).HasMaxLength(500);
            builder.Property(v => v.Price).HasPrecision(10, 2);

            builder.Property(v => v.VehicleId)
                .UseIdentityColumn(1,1);

            builder.HasIndex(v => v.Slug)
                .IsUnique();

            //builder.HasOne(v=> v.SaleHistory)
            //    .WithOne(sh=> sh.Vehicle)
            //    .HasForeignKey<Domain.Entities.Sales.SaleHistory>(sh=> sh.VehicleId)
            //    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
