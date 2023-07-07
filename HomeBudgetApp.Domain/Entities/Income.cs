using HomeBudgetApp.Domain.Commons;
using HomeBudgetApp.Domain.States;

namespace HomeBudgetApp.Domain.Entities
{
    public class Income : BaseAuditableEntity
    {
        public decimal Amount { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public string Comment { get; set; }
    }
}
