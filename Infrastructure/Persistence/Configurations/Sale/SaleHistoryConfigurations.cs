using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Domain.Entities.Sales;

namespace ZK.Persistence.Configurations.Sale
{
    public class SaleHistoryConfigurations : IEntityTypeConfiguration<SaleHistory>
    {
        public void Configure(EntityTypeBuilder<SaleHistory> builder)
        {
            builder.ToTable("SaleHistories");

            builder.HasKey(sh => sh.SaleHistoryId).IsClustered(true);
            builder.Property(sh => sh.VehicleId).IsRequired();
            builder.Property(sh => sh.SaleDateTime).IsRequired();
            builder.Property(sh => sh.SalePrice).HasPrecision(10, 2);
            builder.Property(sh => sh.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(sh => sh.CustomerPhoneNo).HasMaxLength(10);
            builder.Property(sh => sh.Notes).HasMaxLength(500);
            
            builder.Property(sh => sh.SaleHistoryId)
                .UseIdentityColumn(1, 1);
        }
    }
}
