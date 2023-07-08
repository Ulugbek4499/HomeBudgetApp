using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpensesByCategory
{
    public record GetExpensesByCategoryQuery : IRequest<Dictionary<string, decimal>>;

    public class GetExpensesByCategoryQueryHandler : IRequestHandler<GetExpensesByCategoryQuery, Dictionary<string, decimal>>
    {
        private readonly IApplicationDbContext _context;

        public GetExpensesByCategoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Dictionary<string, decimal>> Handle(GetExpensesByCategoryQuery request, CancellationToken cancellationToken)
        {
            Dictionary<string, decimal> result= new Dictionary<string, decimal>();

            decimal totalFoodAmount = _context.Expenses
                                  .Where(e => e.ExpenseCategory == ExpenseCategory.Food)
                                  .Sum(e => e.Amount);
            result.Add("Food", totalFoodAmount);

            decimal totalTransportAmount = _context.Expenses
                                 .Where(e => e.ExpenseCategory == ExpenseCategory.Transport)
                                 .Sum(e => e.Amount);
            result.Add("Transport", totalFoodAmount);

            decimal totalMobileNetworkAmount = _context.Expenses
                                 .Where(e => e.ExpenseCategory == ExpenseCategory.MobileNetwork)
                                 .Sum(e => e.Amount);
            result.Add("MobileNetwork", totalFoodAmount);

            decimal totalUtilitiesAmount = _context.Expenses
                                 .Where(e => e.ExpenseCategory == ExpenseCategory.Utilities)
                                 .Sum(e => e.Amount);
            result.Add("Utilities", totalFoodAmount);

            decimal totalRentalAmount = _context.Expenses
                                 .Where(e => e.ExpenseCategory == ExpenseCategory.Rental)
                                 .Sum(e => e.Amount);
            result.Add("Rental", totalFoodAmount);

            decimal totalOthersAmount = _context.Expenses
                                 .Where(e => e.ExpenseCategory == ExpenseCategory.Others)
                                 .Sum(e => e.Amount);
            result.Add("Others", totalFoodAmount);

            return result;
        }
    }
}
