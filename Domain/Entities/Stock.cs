using Domain.Common;

namespace Domain.Entities
{
    public class Stock : FullAuditable
    {
        public int ProductId { get; set; }
        public decimal ProductExistence { get; set; }
        public decimal Price { get; set; }
        public virtual Product? Product { get; set; }
    }
}
