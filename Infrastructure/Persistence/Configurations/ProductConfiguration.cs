using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(product => product.Name).IsRequired().HasMaxLength(70);
            builder.Property(product => product.Details).IsRequired().HasMaxLength(150);
            builder.Property(product => product.IsActive).HasDefaultValue(true);
            builder.Property(product => product.SoldBy).IsRequired().HasMaxLength(30);
            builder.HasOne(product => product.Category).WithMany().HasForeignKey(product => product.CategoryId).IsRequired();
        }
    }
}
