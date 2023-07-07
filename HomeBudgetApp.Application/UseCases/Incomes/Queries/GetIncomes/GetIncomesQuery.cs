using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncomes
{
    public record GetIncomesQuery : IRequest<IncomeDto[]>;
}
