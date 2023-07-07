using HomeBudgetApp.Application.Commons.Interfaces;

namespace HomeBudgetApp.Infrastructure.Services
{
    public class GuidGeneratorService : IGuidGenerator
    {
        public Guid Guid => Guid.NewGuid();
    }
}
