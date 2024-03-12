using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Categories.ViewModel;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetCategoryByIdCommandHandler> logger) : IRequestHandler<GetCategoryByIdCommand, CategoryViewModel>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetCategoryByIdCommandHandler> _logger = logger;

        public async Task<CategoryViewModel> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Category), request.Id);

            return _mapper.Map<Category, CategoryViewModel>(category);
        }
    }
}
