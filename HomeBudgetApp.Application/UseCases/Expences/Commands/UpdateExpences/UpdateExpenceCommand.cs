using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.States;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.UpdateExpences
{
    public class UpdateExpenceCommand :IRequest<ExpenceDto>
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenceCategory ExpenceCategory { get; set; }
        public string Comment { get; set; }
    }
}
