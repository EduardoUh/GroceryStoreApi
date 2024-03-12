using Domain.Entities;

namespace Application.Specifications.Categories
{
    public class CategoryForCountingSpecification : BaseSpecification<Category>
    {
        public CategoryForCountingSpecification() { }
        public CategoryForCountingSpecification(string name)
            : base(category => string.IsNullOrWhiteSpace(name) || category.Name == name) { }
        public CategoryForCountingSpecification(CategorySpecificationParams categoryParams)
            : base(category => string.IsNullOrWhiteSpace(categoryParams.Search) || category.Name.Contains(categoryParams.Search)) { }
    }
}
