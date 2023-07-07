using AutoMapper;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Application.UseCases.Expences.Commands.CreateExpences;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.CreateExpence
{
    public class CreateExpenceCommandHandler : IRequestHandler<CreateExpenceCommand, ExpenceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateExpenceCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExpenceDto> Handle(CreateExpenceCommand request, CancellationToken cancellationToken)
        {
            var expence = new Expence()
            {
                Amount = request.Amount,
                Comment = request.Comment,
                ExpenceCategory = request.ExpenceCategory
            };

            expence = _context.Expences.Add(expence).Entity;

            await _context.SaveChangesAsync(cancellationToken);
            //await _mediator.Publish();

            return _mapper.Map<ExpenceDto>(expence);
        }
    }
}
