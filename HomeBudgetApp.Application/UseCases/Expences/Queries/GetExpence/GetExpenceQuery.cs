using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Queries.GetExpence
{
    public record GetExpenceQuery(Guid ExpenceId) : IRequest<ExpenceDto>;

}
