using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger) : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly IAsyncRepository<Category> _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger = logger;

        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null) throw new NotFoundException(nameof(UpdateCategoryCommand), request.Id);

            //          source  - destination - type of source          - type of the destination
            _mapper.Map(request, category, typeof(UpdateCategoryCommand), typeof(Category));

            await _categoryRepository.UpdateAsync(category);

            return category.Id;
        }
    }
}
