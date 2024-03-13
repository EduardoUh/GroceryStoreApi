using Domain.Entities;

namespace Application.Specifications.Products
{
    public class ProductForCountingSpecification : BaseSpecification<Product>
    {
        public ProductForCountingSpecification() { }
        public ProductForCountingSpecification(string name) : base(product => string.IsNullOrWhiteSpace(name) || product.Name.Equals(name)) { }
    }
}
