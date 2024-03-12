using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");
            builder.Property(stock => stock.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(stock => stock.ProductExistence).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(stock => stock.Product).WithOne().HasForeignKey<Stock>(stock => stock.ProductId).IsRequired();
        }
    }
}
