using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Incomes.Notifications
{
    public record IncomeDeletedNotification(string comment, decimal amount) : INotification;

    public class IncomeDeletedNotificationHandler : INotificationHandler<IncomeDeletedNotification>
    {
        public Task Handle(IncomeDeletedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"HomeBudget: Income DELETED with comment: ' {notification.comment} ' and amount is: ' {notification.amount} '.");

            return Task.CompletedTask;
        }
    }
}
