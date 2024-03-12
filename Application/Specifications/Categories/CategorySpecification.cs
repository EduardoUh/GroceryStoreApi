using Domain.Entities;

namespace Application.Specifications.Categories
{
    public class CategorySpecification : BaseSpecification<Category>
    {
        public CategorySpecification(CategorySpecificationParams categoryParams)
            : base(category => string.IsNullOrWhiteSpace(categoryParams.Search) || category.Name.Contains(categoryParams.Search))
        {
            ApplyPagination(categoryParams.PageSize, categoryParams.PageSize * (categoryParams.PageIndex - 1));

            if (!string.IsNullOrWhiteSpace(categoryParams.Sort))
            {
                switch (categoryParams.Sort)
                {
                    case "NameAsc":
                        AddOrderByExpression(category => category.Name);
                        break;
                    case "NameDesc":
                        AddOrderByDescendingExpression(category => category.Name);
                        break;
                    case "DateAsc":
                        AddOrderByExpression(category => category.CreationDate);
                        break;
                    case "DateDesc":
                        AddOrderByDescendingExpression(category => category.CreationDate);
                        break;
                    default:
                        AddOrderByExpression(category => category.Name);
                        break;
                }
            }
            else
            {
                AddOrderByExpression(category => category.Name);
            }
        }
    }
}
