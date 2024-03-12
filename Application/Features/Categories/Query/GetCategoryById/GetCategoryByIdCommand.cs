using Application.Features.Categories.ViewModel;
using MediatR;

namespace Application.Features.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdCommand : IRequest<CategoryViewModel>
    {
        public int Id { get; set; }
    }
}
