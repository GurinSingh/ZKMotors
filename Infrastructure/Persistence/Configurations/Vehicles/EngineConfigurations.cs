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
    public class EngineConfigurations : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.ToTable("Engines");

            builder.HasKey(e => e.EngineId).IsClustered(true);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(200);
            
            builder.Property(e => e.EngineId)
                .UseIdentityColumn(1, 1);
            
            builder.HasIndex(e => e.Name)
                .IsUnique();
            
            builder.HasMany(e => e.Vehicles)
                .WithOne(v => v.Engine)
                .HasForeignKey(v => v.EngineId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
