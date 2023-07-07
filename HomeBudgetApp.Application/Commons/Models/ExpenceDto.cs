using HomeBudgetApp.Domain.States;

namespace HomeBudgetApp.Application.Commons.Models
{
    public class ExpenceDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenceCategory ExpenceCategory { get; set; }
        public string Comment { get; set; }
    }
}
