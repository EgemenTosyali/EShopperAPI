using EShopperAPI.Application.ViewModels.Products;
using FluentValidation;

namespace EShopperAPI.Application.Validators
{
    public class CreateProduct_Validator : AbstractValidator<CreateProduct_ViewModel>
    {
        public CreateProduct_Validator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Name cannot be empty!!!")
                .MaximumLength(50)
                .MinimumLength(2)
                    .WithMessage("Name length must be between 3 and 150!!!");

            RuleFor(s => s.Stock)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Stock cannot be empty!!!")
                .Must(s => s >= 0)
                    .WithMessage("Stock must be or higher than 0!!!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Price cannot be empty!!!")
                .Must(p => p > 0)
                    .WithMessage("Price must be higher than 0!!!");
        }
    }
}
