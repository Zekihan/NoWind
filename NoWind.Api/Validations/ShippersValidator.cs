using FluentValidation;
using NoWind.Api.Resources;

namespace NoWind.Api.Validations
{
    public class ShippersValidator : AbstractValidator<ShipperResource>
    {
        public ShippersValidator()
        {
            RuleFor(a => a.CompanyName)
                    .NotEmpty()
                    .WithMessage("Cannot to be empty.");
        }
    }
}
