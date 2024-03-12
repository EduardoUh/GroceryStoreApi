using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.Property(payment => payment.PreviousBalance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(payment => payment.PaidWith).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(payment => payment.AmountPaid).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(payment => payment.Change).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(payment => payment.NewBalance).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
