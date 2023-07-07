using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Queries.GetExpence
{
    public class GetExpenceQueryHandler : IRequestHandler<GetExpenceQuery, ExpenceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExpenceQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExpenceDto> Handle(GetExpenceQuery request, CancellationToken cancellationToken)
        {
            Expence maybeExpence = await _context.Expences
                .FindAsync(new object[] { request.ExpenceId });

            ValidateExpenceIsNotNull(request, maybeExpence);

            return _mapper.Map<ExpenceDto>(maybeExpence);
        }

        private static void ValidateExpenceIsNotNull(GetExpenceQuery request, Expence maybeExpence)
        {
            if (maybeExpence == null)
            {
                throw new NotFoundException(nameof(Expence), request.ExpenceId);
            }
        }
    }
}
