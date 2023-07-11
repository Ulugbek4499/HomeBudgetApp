using FluentValidation;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.UpdateExpenses
{
    public class UpdateExpenseCommandValidation : AbstractValidator<UpdateExpenseCommand>
    {
        public UpdateExpenseCommandValidation()
        {
            RuleFor(e => e.Id)
              .NotEmpty()
              .NotNull()
              .WithMessage("Expense Id is required");

            RuleFor(e => e.Comment)
                  .NotEmpty()
                  .NotNull()
                  .MinimumLength(5)
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
