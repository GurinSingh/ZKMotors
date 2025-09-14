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
    public class DrivetrainConfigurations : IEntityTypeConfiguration<Drivetrain>
    {
        public void Configure(EntityTypeBuilder<Drivetrain> builder)
        {
            builder.ToTable("Drivetrains");

            builder.HasKey(dt => dt.DrivetrainId).IsClustered(true);
            builder.Property(dt => dt.Name).IsRequired().HasMaxLength(50);
            builder.Property(dt => dt.Description).HasMaxLength(200);
            
            builder.Property(dt => dt.DrivetrainId)
                .UseIdentityColumn(1, 1);
            
            builder.HasIndex(dt => dt.Name)
                .IsUnique();

            builder.HasMany(dt => dt.Vehicles)
                .WithOne(v => v.Drivetrain)
                .HasForeignKey(v => v.DrivetrainId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
