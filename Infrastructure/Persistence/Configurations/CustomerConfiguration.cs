using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(customer => customer.Name).IsRequired().HasMaxLength(70);
            builder.Property(customer => customer.LastName).IsRequired().HasMaxLength(70);
            builder.Property(customer => customer.Phone).IsRequired().HasMaxLength(15);
            builder.Property(customer => customer.Address).IsRequired().HasMaxLength(100);
            builder.Property(customer => customer.IsActive).HasDefaultValue(true);
        }
    }
}
