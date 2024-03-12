using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Product : FullAuditable
    {
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public SoldBy SoldBy { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
