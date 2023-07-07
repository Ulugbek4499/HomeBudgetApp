using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpense
{
    public record GetExpenseQuery(Guid ExpenseId) : IRequest<ExpenseDto>;

}
