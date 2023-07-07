using HomeBudgetApp.Domain.Commons;
using HomeBudgetApp.Domain.States;

namespace HomeBudgetApp.Domain.Entities
{
    public class Expence : BaseAuditableEntity
    {
        public decimal Amount { get; set; }
        public ExpenceCategory ExpenceCategory { get; set; }
        public string Comment { get; set; }
    }
}
