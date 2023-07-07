using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpenses
{
    public record GetExpensesQuery : IRequest<ExpenseDto[]>;
}
