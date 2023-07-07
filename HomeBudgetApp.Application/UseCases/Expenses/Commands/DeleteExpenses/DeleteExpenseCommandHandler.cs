using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.DeleteExpenses
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, ExpenseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteExpenseCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExpenseDto> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense? maybeExpense = await
                   _context.Expenses.FindAsync(new object[] { request.ExpenseId });

            ValidateExpenseIsNotNull(request, maybeExpense);

            _context.Expenses.Remove(maybeExpense);

            await _context.SaveChangesAsync(cancellationToken);

            //  await _mediator.Publish(new ExpenseDeletedNotification(maybeExpense.Title));

            return _mapper.Map<ExpenseDto>(maybeExpense);
        }

        private void ValidateExpenseIsNotNull(DeleteExpenseCommand request, Expense? maybeExpense)
        {
            if (maybeExpense is null)
            {
                throw new NotFoundException(nameof(Expense), request.ExpenseId);
            }
        }
    }
}
