using Application.Features.Categories.ViewModel;
using Application.Features.Shared;
using MediatR;

namespace Application.Features.Categories.Query.GetPaginatedCategories
{
    public class GetPaginatedCategoriesQuery : PaginationBaseQuery, IRequest<PaginationViewModel<CategoryViewModel>>
    {
    }
}
