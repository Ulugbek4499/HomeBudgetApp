using System.Globalization;
using HomeBudgetApp.Application.Commons.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpensesByMonths
{
    public record GetExpensesByMonthQuery : IRequest<List<object>>;

    public class GetExpensesByMonthQueryHandler : IRequestHandler<GetExpensesByMonthQuery, List<object>>
    {
        private readonly IApplicationDbContext _context;

        public GetExpensesByMonthQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> Handle(GetExpensesByMonthQuery request, CancellationToken cancellationToken)
        {
            var data = new List<object>();

            var monthYearNames = _context.Expenses
                .GroupBy(e => new { e.Time.Year, e.Time.Month })
                .Select(g => new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM yyyy"))
                .ToList();

            data.Add(monthYearNames);

            var totalAmounts = new List<decimal>();

            foreach (var monthYear in monthYearNames)
            {
                DateTime parsedMonthYear = DateTime.ParseExact(monthYear, "MMMM yyyy", CultureInfo.InvariantCulture);

                decimal totalAmount = await _context.Expenses
                    .Where(e => e.Time.Year == parsedMonthYear.Year && e.Time.Month == parsedMonthYear.Month)
                    .SumAsync(e => e.Amount);

                totalAmounts.Add(totalAmount);
            }

            data.Add(totalAmounts);

            return data;
        }
    }
}
