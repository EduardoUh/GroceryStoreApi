using Domain.Common;

namespace Domain.Entities
{
    public class Vendor : FullAuditable
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
