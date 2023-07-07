using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expenses.Commands.CreateExpenses
{
    public class CreateExpenseCommand : IRequest<ExpenseDto>
    {
        public decimal Amount { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public string Comment { get; set; }
    }

}
