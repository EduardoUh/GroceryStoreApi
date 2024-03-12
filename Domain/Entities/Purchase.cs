using Domain.Common;

namespace Domain.Entities
{
    public class Purchase : SimpleAuditable
    {
        public int VendorId { get; set; }
        public decimal Total { get; set; }
        public virtual Vendor? Vendor { get; set; }
        public virtual ICollection<PurchaseProduct>? PurchaseProducts { get; set; }
    }
}
