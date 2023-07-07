using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Queries.GetExpences
{
    public record GetExpencesQuery : IRequest<ExpenceDto[]>;
}
