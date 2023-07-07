using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.DeleteIncomes
{
    public record DeleteIncomeCommand(Guid IncomeId) : IRequest<IncomeDto>;
}
