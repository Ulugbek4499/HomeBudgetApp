using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.UpdateExpenses
{
    public class UpdateExpenseCommand : IRequest<ExpenseDto>
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public string Comment { get; set; }
    }
}
