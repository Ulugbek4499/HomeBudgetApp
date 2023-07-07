using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncome
{
    public class GetIncomeQueryHandler : IRequestHandler<GetIncomeQuery, IncomeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIncomeQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IncomeDto> Handle(GetIncomeQuery request, CancellationToken cancellationToken)
        {
            Income maybeIncome = await _context.Incomes
                .FindAsync(new object[] { request.IncomeId });

            ValidateIncomeIsNotNull(request, maybeIncome);

            return _mapper.Map<IncomeDto>(maybeIncome);
        }

        private static void ValidateIncomeIsNotNull(GetIncomeQuery request, Income maybeIncome)
        {
            if (maybeIncome == null)
            {
                throw new NotFoundException(nameof(Income), request.IncomeId);
            }
        }
    }
}
