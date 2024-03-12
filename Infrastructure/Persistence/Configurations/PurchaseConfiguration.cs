using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchases");
            builder.Property(purchase => purchase.Total).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(purchase => purchase.Vendor).WithMany().HasForeignKey(purchase => purchase.VendorId).IsRequired();
            builder.HasMany(purchase => purchase.PurchaseProducts).WithOne().HasForeignKey(purchaseProduct => purchaseProduct.PurchaseId);
        }
    }
}
