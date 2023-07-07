using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpense
{
    public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, ExpenseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExpenseQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
        {
            Expense maybeExpense = await _context.Expenses
                .FindAsync(new object[] { request.ExpenseId });

            ValidateExpenseIsNotNull(request, maybeExpense);

            return _mapper.Map<ExpenseDto>(maybeExpense);
        }

        private static void ValidateExpenseIsNotNull(GetExpenseQuery request, Expense maybeExpense)
        {
            if (maybeExpense == null)
            {
                throw new NotFoundException(nameof(Expense), request.ExpenseId);
            }
        }
    }
}
