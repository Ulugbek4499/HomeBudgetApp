using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.CreateIncomes
{
    public class CreateIncomeCommand : IRequest<IncomeDto>
    {
        public decimal Amount { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
    }
}
