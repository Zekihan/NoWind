using FluentValidation;
using NoWind.Api.Resources;

namespace NoWind.Api.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerResource>
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