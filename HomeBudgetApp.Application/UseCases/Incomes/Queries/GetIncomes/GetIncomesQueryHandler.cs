using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncomes
{
    public class GetIncomesQueryHandler : IRequestHandler<GetIncomesQuery, IncomeDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIncomesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IncomeDto[]> Handle(GetIncomesQuery request, CancellationToken cancellationToken)
        {
            Income[] Incomes = await _context.Incomes.ToArrayAsync();

            return _mapper.Map<IncomeDto[]>(Incomes);
        }
    }
}
