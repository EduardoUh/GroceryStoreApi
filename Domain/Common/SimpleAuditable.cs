namespace Domain.Common
{
    public class SimpleAuditable : BaseDomainModel
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
