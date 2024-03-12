
namespace Domain.Common
{
    public class FullAuditable : BaseDomainModel
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
