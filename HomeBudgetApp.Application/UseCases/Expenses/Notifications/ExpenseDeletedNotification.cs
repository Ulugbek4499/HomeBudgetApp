using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Expenses.Notifications
{
    public record ExpenseDeletedNotification(string comment, decimal amount) : INotification;

    public class ExpenseDeletedNotificationHandler : INotificationHandler<ExpenseDeletedNotification>
    {
        public Task Handle(ExpenseDeletedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"HomeBudget: Expense DELETED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");

            return Task.CompletedTask;
        }
    }
}
