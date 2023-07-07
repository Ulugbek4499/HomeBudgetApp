using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands
{
    public record DeleteExpenseCommand(Guid ExpenseId) : IRequest<ExpenseDto>;
}
