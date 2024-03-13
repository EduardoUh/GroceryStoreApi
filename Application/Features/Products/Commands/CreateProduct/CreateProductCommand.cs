using Domain.Enums;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        private string _name = string.Empty;
        private string _details = string.Empty;
        public string Name { get => _name; set => _name = value.Trim().ToUpper(); }
        public string Details { get => _details; set => _details = value.Trim().ToUpper(); }
        public SoldBy SoldBy { get; set; }
        public int CategoryId { get; set; }
    }
}
