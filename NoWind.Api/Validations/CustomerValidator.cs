using FluentValidation;
using NoWind.Api.APIModels;

namespace NoWind.Api.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerAPIModel>
    {
        public CustomerValidator()
        {
            RuleFor(a => a.CustomerId)
                .NotEmpty()
                .MaximumLength(5)
                .MinimumLength(5)
                .WithMessage("Has to be 5 char lenght.");
        }
    }
}