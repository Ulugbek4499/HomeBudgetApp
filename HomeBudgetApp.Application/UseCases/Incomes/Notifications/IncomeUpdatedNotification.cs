using HomeBudgetApp.Domain.Entities;
using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Incomes.Notifications
{
    public record IncomeUpdatedNotification(Income oldIncome, Income updatedIncome) : INotification;
    public class IncomeUpdatedNotificationHandler : INotificationHandler<IncomeUpdatedNotification>
    {
        public Task Handle(IncomeUpdatedNotification notification, CancellationToken cancellationToken)
        {

            Log.Information($"HomeBudget: Update Income notification " + $"Actual Income: Comment: {notification.oldIncome.Comment} Amount: {notification.oldIncome.Amount} \n + $\"Updated Income: Comment: {notification.updatedIncome.Comment} Amount: {notification.updatedIncome.Amount}");


            return Task.CompletedTask;
        }
    }
}
