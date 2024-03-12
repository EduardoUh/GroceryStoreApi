namespace Application.Features.Shared
{
    public class PaginationBaseQuery
    {
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
