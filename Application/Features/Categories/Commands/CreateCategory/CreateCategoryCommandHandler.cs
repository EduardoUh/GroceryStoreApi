using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Specifications.Categories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger) : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IAsyncRepository<Category> _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateCategoryCommandHandler> _logger = logger;

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var spec = new CategoryForCountingSpecification(request.Name);
            var result = await _categoryRepository.CountAsync(spec);

            if (result > 0)
            {
                throw new ConflictException($"A category with the name {request.Name} already exists.");
            }

            var category = _mapper.Map<Category>(request);

            var newCategory = await _categoryRepository.AddAsync(category);

            _logger.LogInformation("Category {name} successfully created", category.Name);

            return newCategory.Id;
        }
    }
}
