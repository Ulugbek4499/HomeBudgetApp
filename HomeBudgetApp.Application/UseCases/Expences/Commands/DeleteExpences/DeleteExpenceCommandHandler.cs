using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.DeleteExpences
{
    public class DeleteExpenceCommandHandler : IRequestHandler<DeleteExpenceCommand, ExpenceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteExpenceCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExpenceDto> Handle(DeleteExpenceCommand request, CancellationToken cancellationToken)
        {
            Expence? maybeExpence = await
                   _context.Expences.FindAsync(new object[] { request.ExpenceId });

            ValidateExpenceIsNotNull(request, maybeExpence);

            _context.Expences.Remove(maybeExpence);

            await _context.SaveChangesAsync(cancellationToken);

            //  await _mediator.Publish(new ExpenceDeletedNotification(maybeExpence.Title));

            return _mapper.Map<ExpenceDto>(maybeExpence);
        }

        private void ValidateExpenceIsNotNull(DeleteExpenceCommand request, Expence? maybeExpence)
        {
            if (maybeExpence is null)
            {
                throw new NotFoundException(nameof(Expence), request.ExpenceId);
            }
        }
    }
}
