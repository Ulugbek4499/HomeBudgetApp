using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Expenses.Notifications
{
    public record ExpenseCreatedNotification(string comment, decimal amount) : INotification;

    public class ExpenseCreatedLogNotificationHandler : INotificationHandler<ExpenseCreatedNotification>
    {
        public Task Handle(ExpenseCreatedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"HomeBudget: New Expense CREATED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");

            return Task.CompletedTask;
        }
    }

    public class ExpenseCreatedConsoleNotificationHandler : INotificationHandler<ExpenseCreatedNotification>
    {
        public async Task Handle(ExpenseCreatedNotification notification, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync($"HomeBudget: New Expense CREATED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");
        }
    }
}
