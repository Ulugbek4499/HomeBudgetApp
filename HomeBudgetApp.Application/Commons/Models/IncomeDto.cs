using HomeBudgetApp.Domain.States;

namespace HomeBudgetApp.Application.Commons.Models
{
    public class IncomeDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public string Comment { get; set; }
    }
}
