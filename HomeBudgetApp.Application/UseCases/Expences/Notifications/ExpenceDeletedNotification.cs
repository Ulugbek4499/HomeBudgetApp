using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Expences.Notifications
{
    public record ExpenceDeletedNotification(string comment, decimal amount) : INotification;

    public class ExpenceDeletedNotificationHandler : INotificationHandler<ExpenceDeletedNotification>
    {
        public Task Handle(ExpenceDeletedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"HomeBudget: Expence DELETED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");

            return Task.CompletedTask;
        }
    }
}
