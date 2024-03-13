using FluentValidation;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("Field {PropertyName} is required");
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Field {PropertyName} is required")
                .MaximumLength(70).WithMessage("Field {PropertyName} should not exceed 70 characters");
            RuleFor(product => product.Details)
                .NotEmpty().WithMessage("Field {PropertyName} is required")
                .MaximumLength(150).WithMessage("Field {PropertyName} should not exceed 150 characters");
            RuleFor(product => product.IsActive)
                .NotNull().WithMessage("Filed {PropertyName} is required");
            RuleFor(product => product.SoldBy)
                .IsInEnum().WithMessage("Field {PropertyName} should be within the predefined values");
            RuleFor(product => product.CategoryId)
                .NotNull().WithMessage("Field {PropertyName} is required")
                .GreaterThan(0).WithMessage("Field {PropertyName} should be greater than 0");
        }
    }
}
