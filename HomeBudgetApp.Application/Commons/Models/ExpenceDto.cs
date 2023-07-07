using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudgetApp.Domain.States;

namespace HomeBudgetApp.Application.Commons.Models
{
    public class ExpenceDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Amount { get; set; }
        public ExpenceCategory ExpenceCategory { get; set; }
        public string Comment { get; set; }
    }
}
