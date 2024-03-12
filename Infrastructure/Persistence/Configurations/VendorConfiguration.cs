using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendors");
            builder.Property(vendor => vendor.Name).IsRequired().HasMaxLength(70);
            builder.Property(vendor => vendor.Phone).IsRequired().HasMaxLength(15);
            builder.Property(vendor => vendor.IsActive).HasDefaultValue(true);
            builder.HasIndex(vendor => vendor.Name).IsUnique();
        }
    }
}
