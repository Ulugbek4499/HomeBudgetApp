using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.DeleteIncomes
{
    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand, IncomeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteIncomeCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IncomeDto> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            Income? maybeIncome = await
                   _context.Incomes.FindAsync(new object[] { request.IncomeId });

            ValidateIncomeIsNotNull(request, maybeIncome);

            _context.Incomes.Remove(maybeIncome);

            await _context.SaveChangesAsync(cancellationToken);

            //  await _mediator.Publish(new IncomeDeletedNotification(maybeIncome.Title));

            return _mapper.Map<IncomeDto>(maybeIncome);
        }

        private void ValidateIncomeIsNotNull(DeleteIncomeCommand request, Income? maybeIncome)
        {
            if (maybeIncome is null)
            {
                throw new NotFoundException(nameof(Income), request.IncomeId);
            }
        }
    }
}
