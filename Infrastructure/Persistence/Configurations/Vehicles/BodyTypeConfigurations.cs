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
    public class BodyTypeConfigurations: IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.ToTable("BodyTypes");

            builder.HasKey(bt => bt.BodyTypeId).IsClustered(true);
            builder.Property(bt => bt.Name).IsRequired().HasMaxLength(50);
            builder.Property(bt => bt.Description).HasMaxLength(200);

            builder.Property(bt => bt.BodyTypeId)
                .UseIdentityColumn(1, 1);
            
            builder.HasIndex(bt => bt.Name)
                .IsUnique();
            
            builder.HasMany(bt => bt.Vehicles)
                .WithOne(v => v.BodyType)
                .HasForeignKey(v => v.BodyTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
