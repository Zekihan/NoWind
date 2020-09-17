using FluentValidation;
using NoWind.Api.Resources;

namespace NoWind.Api.Validations
{
    public class EmployeesValidator : AbstractValidator<EmployeesResource>
    {
        public EmployeesValidator(int s)
        {
            if (s == 1)
            {
                RuleFor(a => a.EmployeeId)
                                .Equal(0)
                                .WithMessage("Id has to be emppty or 0.")
                                .Empty().WithMessage("Id has to empty or 0");

                RuleFor(a => a.FirstName)
                    .NotEmpty()
                    .WithMessage("Cannot to be emptyt.");
            }
            else if (s == 0)
            {
                RuleFor(a => a.EmployeeId)
                .NotEmpty().WithMessage("Id cannot empty or 0");

                RuleFor(a => a.FirstName)
                    .NotEmpty()
                    .WithMessage("Cannot to be emptyt.");
            }
        }
    }
}
