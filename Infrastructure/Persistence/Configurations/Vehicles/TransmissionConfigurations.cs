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
    public class TransmissionConfigurations: IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.ToTable("Transmissions");

            builder.HasKey(t => t.TransmissionId).IsClustered(true);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(200);
            
            builder.Property(t => t.TransmissionId)
                .UseIdentityColumn(1, 1);
            
            builder.HasIndex(t => t.Name)
                .IsUnique();
            
            builder.HasMany(t => t.Vehicles)
                .WithOne(v=> v.Transmission)
                .HasForeignKey(v => v.TransmissionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
