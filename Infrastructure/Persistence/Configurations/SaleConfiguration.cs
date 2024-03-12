using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.Property(sale => sale.Total).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(sale => sale.Balance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(sale => sale.Settled).IsRequired();
            builder.Property(sale => sale.Credit).IsRequired();
            builder.HasOne(sale => sale.Customer).WithMany().HasForeignKey(sale => sale.CustomerId).IsRequired();
            builder.HasMany(sale => sale.SaleProducts).WithOne().HasForeignKey(saleProduct => saleProduct.SaleId);
            builder.HasMany(sale => sale.Payments).WithOne().HasForeignKey(payment => payment.SaleId);
        }
    }
}
