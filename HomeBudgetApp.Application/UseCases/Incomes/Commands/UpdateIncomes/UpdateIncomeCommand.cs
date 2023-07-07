using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.UpdateIncomes
{
    public class UpdateIncomeCommand : IRequest<IncomeDto>
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public string Comment { get; set; }
    }
}
