using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Domain.States;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncomesByCategory
{
    public record GetIncomesByCategoryQuery : IRequest<List<object>>;

    public class GetIncomesByCategoryQueryHandler : IRequestHandler<GetIncomesByCategoryQuery, List<object>>
    {
        private readonly IApplicationDbContext _context;

        public GetIncomesByCategoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<object>> Handle(GetIncomesByCategoryQuery request, CancellationToken cancellationToken)
        {
            List<object> data = new List<object>();

            List<string> categoryNames = Enum.GetNames(typeof(IncomeCategory)).ToList();
            data.Add(categoryNames);

            List<decimal> totalAmounts = new List<decimal>();

            foreach (IncomeCategory category in Enum.GetValues(typeof(IncomeCategory)))
            {
                decimal totalAmount = await _context.Incomes
                    .Where(e => e.IncomeCategory == category)
                    .SumAsync(e => e.Amount);

                totalAmounts.Add(totalAmount);
            }

            data.Add(totalAmounts);

            return data;
        }
    }
}
