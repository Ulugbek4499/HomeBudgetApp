using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetApp.Application.UseCases.Expences.Queries.GetExpences
{
    public class GetExpencesQueryHandler : IRequestHandler<GetExpencesQuery, ExpenceDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExpencesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExpenceDto[]> Handle(GetExpencesQuery request, CancellationToken cancellationToken)
        {
            Expence[] Expences = await _context.Expences.ToArrayAsync();

            return _mapper.Map<ExpenceDto[]>(Expences);
        }
    }
}
