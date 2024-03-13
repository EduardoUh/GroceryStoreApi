using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Specifications.Products;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateProductCommandHandler> logger, IMapper mapper) : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<UpdateProductCommandHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductForCountingSpecification(request.Name);

            var result = await _unitOfWork.Repository<Product>().CountAsync(spec);

            if (result > 0)
            {
                _logger.LogError($"A product with the name {request.Name} already exists in the database");

                throw new ConflictException($"A product with the name {request.Name} already exists");
            }

            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                _logger.LogError($"Couldn't find a category with the id {request.CategoryId}");

                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);

            if (product == null)
            {
                _logger.LogError($"Couldn't find a product with the id {request.Id}");

                throw new NotFoundException(nameof(Product), request.Id);
            }

            _mapper.Map(request, product, typeof(UpdateProductCommand), typeof(Product));

            _unitOfWork.Repository<Product>().UpdateEntity(product);

            result = await _unitOfWork.Complete();

            if (result < 1)
            {
                _logger.LogError($"Couldn't update product with the id {request.Id}");

                throw new BadRequestException($"Couldn't update product with the id {request.Id}");
            }

            return request.Id;
        }
    }
}
