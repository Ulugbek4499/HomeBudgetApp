using HomeBudgetApp.Application.Commons.Interfaces;

namespace HomeBudgetApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
