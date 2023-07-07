using HomeBudgetApp.Domain.States;

namespace HomeBudgetApp.Application.Commons.Models
{
    public class ExpenseDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public string Comment { get; set; }
    }
}
