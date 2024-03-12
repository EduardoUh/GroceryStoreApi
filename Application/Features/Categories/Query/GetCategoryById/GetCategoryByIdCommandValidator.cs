using FluentValidation;

namespace Application.Features.Categories.Query.GetCategoryById
{
    public class GetCategoryByIdCommandValidator : AbstractValidator<GetCategoryByIdCommand>
    {
        public GetCategoryByIdCommandValidator()
        {
            RuleFor(category => category.Id).NotNull().WithMessage("Id is required");
        }
    }
}
