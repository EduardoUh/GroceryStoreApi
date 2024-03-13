using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Field {PropertyName} is required")
                .MaximumLength(70).WithMessage("Field {PropertyName} should not exceed 70 characters");
            RuleFor(product => product.Details)
                .NotEmpty().WithMessage("Field {PropertyName} is required")
                .MaximumLength(150).WithMessage("Field {PropertyName} should not exceed 150 characters");
            RuleFor(product => product.CategoryId)
                .NotNull().WithMessage("Field {PropertyName} is required")
                .GreaterThan(0).WithMessage("Field {PropertyName} should be greater than 0");
            RuleFor(product => product.SoldBy)
                .NotEmpty().WithMessage("Field {PropertyName} is required")
                .IsInEnum().WithMessage("Field {PropertyName} should be within the predefined values");
        }
    }
}
