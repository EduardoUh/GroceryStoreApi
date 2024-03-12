using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Field Name is required")
                .MaximumLength(50).WithMessage("Field Name should not exceed 50 characters");
        }
    }
}
