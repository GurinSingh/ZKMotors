using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Vehicles;

namespace ZK.Persistence.Configurations
{
    public sealed class VehicleModelConfigurations : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable("VehicleModels");

            builder.HasKey(vm => vm.VehicleModelId).IsClustered(true);
            builder.Property(vm => vm.VehicleModelId);
            builder.Property(vm => vm.Name).IsRequired().HasMaxLength(100);

            builder.Property(v => v.VehicleModelId)
                .UseIdentityColumn(1, 1);

            builder.HasMany<Vehicle>(vm => vm.Vehicles)
                .WithOne(v => v.Model)
                .HasForeignKey(v => v.ModelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
