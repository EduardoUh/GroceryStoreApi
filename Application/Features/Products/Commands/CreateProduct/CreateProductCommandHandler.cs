using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Specifications.Products;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IAsyncRepository<Product> productRepository, ILogger<CreateProductCommandHandler> logger, IMapper mapper) : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAsyncRepository<Product> _productRepository = productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductForCountingSpecification(request.Name);

            var result = await _productRepository.CountAsync(spec);

            if (result > 0)
            {
                _logger.LogError($"A product with the name {request.Name} already exists in the database");

                throw new ConflictException($"A product with the name {request.Name} already exists");
            }

            var product = _mapper.Map<Product>(request);

            product.IsActive = true;

            var newProduct = await _productRepository.AddAsync(product);

            return newProduct.Id;
        }
    }
}
