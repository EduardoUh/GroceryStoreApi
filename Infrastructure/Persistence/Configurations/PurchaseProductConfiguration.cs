using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    /*
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
     */
    public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
    {
        public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
        {
            builder.ToTable("PurchasesProducts");
            builder.Property(purchaseProduct => purchaseProduct.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(purchaseProduct => purchaseProduct.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(purchaseProduct => purchaseProduct.Total).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(purchaseProduct => purchaseProduct.Product).WithMany().HasForeignKey(purchaseProduct => purchaseProduct.ProductId);
        }
    }
}
