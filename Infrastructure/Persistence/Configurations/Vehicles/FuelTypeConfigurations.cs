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
    public class FuelTypeConfigurations : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.ToTable("FuelTypes");

            builder.HasKey(ft => ft.FuelTypeId).IsClustered(true);
            builder.Property(ft => ft.Name).IsRequired().HasMaxLength(50);
            builder.Property(ft => ft.Description).HasMaxLength(200);
            
            builder.Property(ft => ft.FuelTypeId)
                .UseIdentityColumn(1, 1);
            
            builder.HasIndex(ft => ft.Name)
                .IsUnique();
            
            builder.HasMany(ft => ft.VehicleTechnicalSpecifications)
                .WithOne(v => v.FuelType)
                .HasForeignKey(v => v.FuelTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
