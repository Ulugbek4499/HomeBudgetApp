﻿using HomeBudgetApp.Application.Commons.Models;
using MediatR;

namespace HomeBudgetApp.Application.UseCases.Expences.Commands
{
    public record DeleteExpenceCommand(Guid ExpenceId) : IRequest<ExpenceDto>;
}
