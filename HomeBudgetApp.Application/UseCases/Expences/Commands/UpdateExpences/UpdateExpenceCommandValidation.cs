using FluentValidation;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.UpdateExpences
{
    public class UpdateExpenceCommandValidation : AbstractValidator<UpdateExpenceCommand>
    {
        public UpdateExpenceCommandValidation()
        {
            RuleFor(e => e.Id)
              .NotEmpty()
              .WithMessage("Expence Id is required");

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
