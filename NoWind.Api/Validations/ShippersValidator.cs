using FluentValidation;
using NoWind.Core.Models;

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
