using FluentValidation;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.CreateIncomes
{
    public class CreateIncomeCommandValidation : AbstractValidator<CreateIncomeCommand>
    {
        public CreateIncomeCommandValidation()
        {
            RuleFor(e => e.Comment)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(100)
               .WithMessage("Comment is required");

            RuleFor(e => e.Amount)
                .NotEmpty()
                .WithMessage("Amount is required.");

            RuleFor(e => e.Time)
             .NotEqual((DateTime)default)
             .WithMessage("Time is required.");
        }
    }
}
