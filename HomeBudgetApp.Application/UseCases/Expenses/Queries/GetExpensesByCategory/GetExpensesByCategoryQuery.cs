using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Domain.States;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpensesByCategory
{
    public record GetExpensesByCategoryQuery : IRequest<List<object>>;

    public class GetExpensesByCategoryQueryHandler : IRequestHandler<GetExpensesByCategoryQuery, List<object>>
    {
        private readonly IApplicationDbContext _context;

        public GetExpensesByCategoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> Handle(GetExpensesByCategoryQuery request, CancellationToken cancellationToken)
        {
            List<object> data = new List<object>();

            List<string> categoryNames = Enum.GetNames(typeof(ExpenseCategory)).ToList();
            data.Add(categoryNames);

            List<decimal> totalAmounts = new List<decimal>();

            foreach (ExpenseCategory category in Enum.GetValues(typeof(ExpenseCategory)))
            {
                decimal totalAmount = await _context.Expenses
                    .Where(e => e.ExpenseCategory == category)
                    .SumAsync(e => e.Amount);

                totalAmounts.Add(totalAmount);
            }

            data.Add(totalAmounts);

            return data;
        }
    }
}
