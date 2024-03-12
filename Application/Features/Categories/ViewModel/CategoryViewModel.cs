namespace Application.Features.Categories.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string LastUpdateBy { get; set; } = string.Empty;
        public DateTime LastUpdateDate { get; set; }
    }
}
