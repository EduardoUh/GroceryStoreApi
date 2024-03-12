using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.ToTable("SalesProducts");
            builder.Property(saleProduct => saleProduct.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(saleProduct => saleProduct.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(saleProduct => saleProduct.Total).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(saleProduct => saleProduct.Product).WithMany().HasForeignKey(saleProduct => saleProduct.ProductId).IsRequired();
        }
    }
}
