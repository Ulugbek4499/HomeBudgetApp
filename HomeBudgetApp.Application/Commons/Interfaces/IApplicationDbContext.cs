using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudgetApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Expence> Expences { get; set; }
        public DbSet<Income> Incomes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
