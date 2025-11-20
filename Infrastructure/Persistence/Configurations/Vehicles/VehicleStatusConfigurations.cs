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
    public class VehicleStatusConfigurations : IEntityTypeConfiguration<VehicleStatus>
    {
        public void Configure(EntityTypeBuilder<VehicleStatus> builder)
        {
            builder.ToTable("VehicleStatuses");

            builder.HasKey(vs => vs.VehicleStatusId);
            builder.Property(vs => vs.Name).IsRequired().HasMaxLength(50);
            
            builder.Property(vs => vs.VehicleStatusId)
                .UseIdentityColumn(1, 1);
            
            builder.HasIndex(vs => vs.Name)
                .IsUnique();

            builder.HasMany(vs=> vs.Vehicles)
                .WithOne(v => v.VehicleStatus)
                .HasForeignKey(v => v.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
