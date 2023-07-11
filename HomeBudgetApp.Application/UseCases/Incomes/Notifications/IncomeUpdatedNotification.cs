using HomeBudgetApp.Domain.Entities;
using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Incomes.Notifications
{
    public record IncomeUpdatedNotification(Income oldIncome, Decimal updatedAmount, string UpdatedComment) : INotification;
    public class IncomeUpdatedNotificationHandler : INotificationHandler<IncomeUpdatedNotification>
    {
        public Task Handle(IncomeUpdatedNotification notification, CancellationToken cancellationToken)
        {

            Log.Information($"HomeBudget: Update Income notification " + $"Actual Income: Comment: {notification.UpdatedComment} Amount: {notification.updatedAmount} \n + $\"Updated Income: Comment: {notification.updatedAmount} Amount: {notification.UpdatedComment}");


            return Task.CompletedTask;
        }
    }
}
