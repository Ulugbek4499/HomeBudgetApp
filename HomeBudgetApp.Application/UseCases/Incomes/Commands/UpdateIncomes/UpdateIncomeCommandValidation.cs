using FluentValidation;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.UpdateIncomes
{
    public class UpdateIncomeCommandValidation : AbstractValidator<UpdateIncomeCommand>
    {
        public UpdateIncomeCommandValidation()
        {
            RuleFor(e => e.Id)
              .NotEmpty()
              .WithMessage("Income Id is required");

            RuleFor(e => e.Comment)
              .NotEmpty()
              .MinimumLength(3)
              .MaximumLength(100)
              .WithMessage("Comment is required");

            RuleFor(e => e.IncomeCategory)
               .NotEmpty()
               .WithMessage("Income Category is required");

            RuleFor(e => e.Amount)
                .NotEmpty()
                .WithMessage("Amount is required.");
        }
    }
}
