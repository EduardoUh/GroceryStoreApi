using Domain.Common;

namespace Domain.Entities
{
    public class Category : FullAuditable
    {
        public string Name { get; set; } = string.Empty;
    }
}
