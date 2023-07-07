using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.CreateExpences
{
    public class CreateExpenceCommand : IRequest<ExpenceDto>
    {
        public decimal Amount { get; set; }
        public ExpenceCategory ExpenceCategory { get; set; }
        public string Comment { get; set; }
    }

}
