using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.UpdateExpenses
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, ExpenseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateExpenseCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExpenseDto> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense maybeExpense = await
                _context.Expenses.FindAsync(new object[] { request.Id });

            ValidateExpenseIsNotNull(request, maybeExpense);

            maybeExpense.Amount = request.Amount;
            maybeExpense.ExpenseCategory = request.ExpenseCategory;
            maybeExpense.Comment = request.Comment;
            maybeExpense.Time = request.Time;

            await _context.SaveChangesAsync(cancellationToken);

            // await _mediator.Publish(new ExpenseUpdatedNotification(maybeExpense.Comment));

            return _mapper.Map<ExpenseDto>(maybeExpense);
        }

        private void ValidateExpenseIsNotNull(UpdateExpenseCommand request, Expense? maybeExpense)
        {
            if (maybeExpense is null)
            {
                throw new NotFoundException(nameof(Expense), request.Id);
            }
        }
    }

}
