namespace Application.Specifications
{
    public class SpecificationParams
    {
        public string? Sort { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int _maxPageSize = 50;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
