using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands.UpdateExpences
{
    public class UpdateExpenceCommandHandler : IRequestHandler<UpdateExpenceCommand, ExpenceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateExpenceCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ExpenceDto> Handle(UpdateExpenceCommand request, CancellationToken cancellationToken)
        {
            Expence maybeExpence = await
                _context.Expences.FindAsync(new object[] { request.Id });

            ValidateExpenceIsNotNull(request, maybeExpence);

            maybeExpence.Amount = request.Amount;
            maybeExpence.ExpenceCategory =request.ExpenceCategory;
            maybeExpence.Comment = request.Comment;

            await _context.SaveChangesAsync(cancellationToken);

            // await _mediator.Publish(new ExpenceUpdatedNotification(maybeExpence.Comment));

            return _mapper.Map<ExpenceDto>(maybeExpence);
        }

        private void ValidateExpenceIsNotNull(UpdateExpenceCommand request, Expence? maybeExpence)
        {
            if (maybeExpence is null)
            {
                throw new NotFoundException(nameof(Expence), request.Id);
            }
        }
    }

}
