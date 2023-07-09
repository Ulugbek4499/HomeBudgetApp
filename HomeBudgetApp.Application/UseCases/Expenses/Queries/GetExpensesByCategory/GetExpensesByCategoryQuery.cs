using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Domain.States;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpensesByCategory
{
    public record GetExpensesByMonthQuery : IRequest<List<object>>;

    public class GetExpensesByCategoryQueryHandler : IRequestHandler<GetExpensesByMonthQuery, List<object>>
    {
        private readonly IApplicationDbContext _context;

        public GetExpensesByCategoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> Handle(GetExpensesByMonthQuery request, CancellationToken cancellationToken)
        {
            /*List<object> data = new List<object>();

            List<string> categoryNames = Enum.GetNames(typeof(ExpenseCategory)).ToList();
            data.Add(categoryNames);

            List<decimal> totalAmounts = new();

            decimal totalAmountFood = await _context.Expenses
                   .Where(e => e.ExpenseCategory == ExpenseCategory.Food)
                    .SumAsync(e => e.Amount);
            totalAmounts.Add(totalAmountFood);

            decimal totalAmountTransport = await _context.Expenses
                 .Where(e => e.ExpenseCategory == ExpenseCategory.Transport)
                  .SumAsync(e => e.Amount);
            totalAmounts.Add(totalAmountTransport);

            decimal totalAmountMobileNetwork = await _context.Expenses
                 .Where(e => e.ExpenseCategory == ExpenseCategory.MobileNetwork)
                  .SumAsync(e => e.Amount);
            totalAmounts.Add(totalAmountMobileNetwork);

            decimal totalAmountUtilities = await _context.Expenses
              .Where(e => e.ExpenseCategory == ExpenseCategory.Utilities)
               .SumAsync(e => e.Amount);
            totalAmounts.Add(totalAmountUtilities);

            decimal totalAmountRental = await _context.Expenses
             .Where(e => e.ExpenseCategory == ExpenseCategory.Rental)
              .SumAsync(e => e.Amount);
            totalAmounts.Add(totalAmountRental);

            decimal totalAmountOthers = await _context.Expenses
             .Where(e => e.ExpenseCategory == ExpenseCategory.Others)
              .SumAsync(e => e.Amount);
            totalAmounts.Add(totalAmountOthers);

            data.Add(totalAmounts);

            return data;*/

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
