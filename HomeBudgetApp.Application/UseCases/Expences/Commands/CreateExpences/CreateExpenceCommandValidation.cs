using FluentValidation;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.CreateExpences
{
    public class CreateExpenceCommandValidation : AbstractValidator<CreateExpenceCommand>
    {
        public CreateExpenceCommandValidation()
        {
            RuleFor(e => e.Comment)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(100)
               .WithMessage("Comment is required");

            RuleFor(e => e.ExpenceCategory)
               .NotEmpty()
               .WithMessage("Expence Category is required");

            RuleFor(e => e.Amount)
                .NotEmpty()
                .WithMessage("Amount is required.");
        }
    }
}
