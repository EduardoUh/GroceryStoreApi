using Application.Contracts.Persistence;
using Application.Features.Categories.ViewModel;
using Application.Features.Shared;
using Application.Specifications.Categories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Query.GetPaginatedCategories
{
    public class GetPaginatedCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetPaginatedCategoriesQuery, PaginationViewModel<CategoryViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginationViewModel<CategoryViewModel>> Handle(GetPaginatedCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categorySpecificationParams = new CategorySpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort
            };

            var categorySpec = new CategorySpecification(categorySpecificationParams);

            var categorySpecForCounting = new CategoryForCountingSpecification(categorySpecificationParams);

            var categories = await _unitOfWork.Repository<Category>().GetAllWithSpec(categorySpec);

            var totalCategories = await _unitOfWork.Repository<Category>().CountAsync(categorySpecForCounting);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalCategories) / Convert.ToDecimal(request.PageSize));

            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<CategoryViewModel>>(categories);

            return new PaginationViewModel<CategoryViewModel>
            {
                Count = totalCategories,
                PageCount = totalPages,
                PageIndex = categorySpecificationParams.PageIndex,
                PageSize = categorySpecificationParams.PageSize,
                Data = data
            };
        }
    }
}
