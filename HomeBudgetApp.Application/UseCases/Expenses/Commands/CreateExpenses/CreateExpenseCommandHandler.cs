using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Application.UseCases.Expenses.Commands.CreateExpenses;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateExpenseCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var Expense = new Expense()
            {
                Amount = request.Amount,
                Comment = request.Comment,
                ExpenseCategory = request.ExpenseCategory
            };

            Expense = _context.Expenses.Add(Expense).Entity;

            await _context.SaveChangesAsync(cancellationToken);
            //await _mediator.Publish();

            return _mapper.Map<ExpenseDto>(Expense);
        }
    }
}
