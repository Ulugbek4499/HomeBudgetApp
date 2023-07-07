using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncome
{
    public record GetIncomeQuery(Guid IncomeId) : IRequest<IncomeDto>;
}
