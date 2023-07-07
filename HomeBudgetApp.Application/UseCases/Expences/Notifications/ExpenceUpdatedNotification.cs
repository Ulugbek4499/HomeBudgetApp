using HomeBudgetApp.Domain.Entities;
using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Expences.Notifications
{
    public record ExpenceUpdatedNotification(Expence oldExpence, Expence updatedExpence) : INotification;
    public class ExpenceUpdatedNotificationHandler : INotificationHandler<ExpenceUpdatedNotification>
    {
        public Task Handle(ExpenceUpdatedNotification notification, CancellationToken cancellationToken)
        {

            Log.Information($"HomeBudget: Update Expence notification " + $"Actual Expence: Comment: {notification.oldExpence.Comment} Amount: {notification.oldExpence.Amount} \n + $\"Updated Expence: Comment: {notification.updatedExpence.Comment} Amount: {notification.updatedExpence.Amount}");


            return Task.CompletedTask;
        }
    }
}
