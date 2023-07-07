using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Incomes.Notifications
{
    public record IncomeCreatedNotification(string comment, decimal amount) : INotification;

    public class IncomeCreatedLogNotificationHandler : INotificationHandler<IncomeCreatedNotification>
    {
        public Task Handle(IncomeCreatedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"HomeBudget: New Income CREATED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");

            return Task.CompletedTask;
        }
    }

    public class IncomeCreatedConsoleNotificationHandler : INotificationHandler<IncomeCreatedNotification>
    {
        public async Task Handle(IncomeCreatedNotification notification, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync($"HomeBudget: New Income CREATED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");
        }
    }
}
