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
    public class VehicleImageConfigurations : IEntityTypeConfiguration<VehicleImage>
    {
        public void Configure(EntityTypeBuilder<VehicleImage> builder)
        {
            builder.ToTable("VehicleImages");

            builder.HasKey(vi => vi.VehicleImageId).IsClustered(true);
            builder.Property(vi=> vi.VehicleId).IsRequired();
            builder.Property(vi => vi.ImageData).IsRequired();
            builder.Property(vi => vi.ContentType).IsRequired().HasMaxLength(100);
            builder.Property(vi => vi.FileName).IsRequired().HasMaxLength(100);

            builder.Property(vi => vi.VehicleImageId)
                .UseIdentityColumn(1, 1);

            builder.HasIndex(vi => vi.VehicleId);
        }
    }
}
