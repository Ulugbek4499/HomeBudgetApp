using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.CreateIncomes
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, IncomeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateIncomeCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IncomeDto> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var Income = new Income()
            {
                Amount = request.Amount,
                Comment = request.Comment,
                IncomeCategory = request.IncomeCategory,
                Time = request.Time,
            };

            Income = _context.Incomes.Add(Income).Entity;

            await _context.SaveChangesAsync(cancellationToken);
            //await _mediator.Publish();

            return _mapper.Map<IncomeDto>(Income);
        }
    }
}
