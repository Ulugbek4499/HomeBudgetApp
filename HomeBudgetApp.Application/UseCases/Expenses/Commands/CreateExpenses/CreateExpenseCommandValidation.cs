using FluentValidation;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.CreateExpenses
{
    public class CreateExpenseCommandValidation : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidation()
        {
            RuleFor(e => e.Comment)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(100)
               .WithMessage("Comment is required");

            RuleFor(e => e.ExpenseCategory)
               .NotEmpty()
               .WithMessage("Expense Category is required");

            RuleFor(e => e.Amount)
                .NotEmpty()
                .WithMessage("Amount is required.");

            RuleFor(e => e.Time)
             .NotEqual((DateTime)default)
             .WithMessage("Time is required.");
        }
    }
}
