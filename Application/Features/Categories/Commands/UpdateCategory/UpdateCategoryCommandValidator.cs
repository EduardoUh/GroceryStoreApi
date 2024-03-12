using FluentValidation;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(category => category.Id)
                .NotNull().WithMessage("Id is required");
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Field Name is required")
                .MaximumLength(50).WithMessage("Field Name should not exceed 50 characters");
        }
    }
}
