using FluentValidation;
using NoWind.Api.Resources;

namespace NoWind.Api.Validations
{
    public class OrderValidator : AbstractValidator<OrderResource>
    {
        public OrderValidator()
        {
            RuleFor(a => a.EmployeeId)
                    .NotEmpty()
                    .WithMessage("Cannot to be empty.");
            RuleFor(a => a.CustomerId)
                    .NotEmpty()
                    .WithMessage("Cannot to be empty.");
            RuleFor(a => a.Customer)
                    .SetValidator(new CustomerValidator())
                    .WithMessage("Cannot to be empty.");
            RuleFor(a => a.Employee)
                    .SetValidator(new EmployeesValidator(1))
                    .WithMessage("Cannot to be empty.");
        }
    }
}
