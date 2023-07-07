using AutoMapper;
using HomeBudgetApp.Application.Commons.Exceptions;
using HomeBudgetApp.Application.Commons.Interfaces;
using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Domain.Entities;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Incomes.Commands.UpdateIncomes
{
    public class UpdateIncomeCommandHandler : IRequestHandler<UpdateIncomeCommand, IncomeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateIncomeCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IncomeDto> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            Income maybeIncome = await
                _context.Incomes.FindAsync(new object[] { request.Id });

            ValidateIncomeIsNotNull(request, maybeIncome);

            maybeIncome.Amount = request.Amount;
            maybeIncome.IncomeCategory = request.IncomeCategory;
            maybeIncome.Comment = request.Comment;

            await _context.SaveChangesAsync(cancellationToken);

            // await _mediator.Publish(new IncomeUpdatedNotification(maybeIncome.Comment));

            return _mapper.Map<IncomeDto>(maybeIncome);
        }

        private void ValidateIncomeIsNotNull(UpdateIncomeCommand request, Income? maybeIncome)
        {
            if (maybeIncome is null)
            {
                throw new NotFoundException(nameof(Income), request.Id);
            }
        }
    }
}
