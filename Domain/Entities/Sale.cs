using Domain.Common;

namespace Domain.Entities
{
    public class Sale : SimpleAuditable
    {
        public int? CustomerId { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public bool Settled { get; set; }
        public bool Credit { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<SaleProduct>? SaleProducts { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
