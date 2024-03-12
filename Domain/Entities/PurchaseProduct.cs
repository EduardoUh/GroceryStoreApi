using Domain.Common;

namespace Domain.Entities
{
    public class PurchaseProduct : BaseDomainModel
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public virtual Product? Product { get; set; }
    }
}
