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
    public sealed class VehicleMakeConfigurations : IEntityTypeConfiguration<VehicleMake>
    {
        public void Configure(EntityTypeBuilder<VehicleMake> builder)
        {
            builder.ToTable("VehicleMakes");

            builder.HasKey(vm => vm.VehicleMakeId).IsClustered(true);
            builder.Property(vm => vm.Name).IsRequired().HasMaxLength(100);
            builder.Property(vm => vm.ImageData).IsRequired();

            builder.Property(v => v.VehicleMakeId)
                .UseIdentityColumn(1, 1);

            builder.HasMany(vm => vm.VehicleBasicIdentifications)
                .WithOne(v => v.Make)
                .HasForeignKey(v => v.MakeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(vm=> vm.VehicleModels)
                .WithOne(vm=> vm.Make)
                .HasForeignKey(vm=> vm.MakeId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
