using FluentValidation;
using NoWind.Api.APIModels;

namespace NoWind.Api.Validations
{
    public class ShipperValidator : AbstractValidator<ShipperAPIModel>
    {
        public ShipperValidator()
        {
            RuleFor(a => a.CompanyName)
                    .NotEmpty()
                    .WithMessage("Cannot to be empty.");
        }
    }
}
