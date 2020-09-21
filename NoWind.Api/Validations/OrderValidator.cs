using FluentValidation;
using NoWind.Api.APIModels;

namespace NoWind.Api.Validations
{
    public class OrderValidator : AbstractValidator<OrderAPIModel>
    {
        public OrderValidator()
        {
            RuleFor(a => a.EmployeeId)
                    .NotEmpty()
                    .WithMessage("Cannot to be empty.");
            RuleFor(a => a.CustomerId)
                    .NotEmpty()
                    .WithMessage("Cannot to be empty.");
        }
    }
}
