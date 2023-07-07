using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Queries.GetExpences
{
    public record GetExpencesQuery : IRequest<ExpenceDto[]>;
}
