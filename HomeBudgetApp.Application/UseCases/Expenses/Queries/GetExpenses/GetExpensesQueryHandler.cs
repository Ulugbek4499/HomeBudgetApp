using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpenses
{
    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, ExpenseDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExpensesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExpenseDto[]> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            Expense[] Expenses = await _context.Expenses.ToArrayAsync();

            return _mapper.Map<ExpenseDto[]>(Expenses);
        }
    }
}
