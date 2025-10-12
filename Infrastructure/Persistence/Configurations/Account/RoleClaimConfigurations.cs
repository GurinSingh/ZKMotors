using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Users;

namespace ZK.Persistence.Configurations.Account
{
    public class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaims");

            builder.HasKey(rc => rc.RoleClaimId).IsClustered(false);
            builder.Property(rc => rc.RoleId).IsRequired();
            builder.Property(rc => rc.ClaimType).IsRequired().HasMaxLength(50);
            builder.Property(rc => rc.ClaimValue).IsRequired().HasMaxLength(255);
            
            builder.Property(rc => rc.RoleClaimId)
                .UseIdentityColumn(1, 1);
            builder.HasIndex(rc => rc.RoleId)
                .IsClustered(true);
            builder.HasIndex(rc=> rc.ClaimValue)
                .IsUnique();
        }
    }
}
