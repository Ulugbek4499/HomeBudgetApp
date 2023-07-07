using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Expences.Notifications
{
    public record ExpenceCreatedNotification(string comment, decimal amount) : INotification;

    public class ExpenceCreatedLogNotificationHandler : INotificationHandler<ExpenceCreatedNotification>
    {
        public Task Handle(ExpenceCreatedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"HomeBudget: New Expence CREATED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");

            return Task.CompletedTask;
        }
    }

    public class ExpenceCreatedConsoleNotificationHandler : INotificationHandler<ExpenceCreatedNotification>
    {
        public async Task Handle(ExpenceCreatedNotification notification, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync($"HomeBudget: New Expence CREATED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");
        }
    }
}
