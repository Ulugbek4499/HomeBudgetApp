using HomeBudgetApp.Domain.Entities;
using MediatR;
using Serilog;

namespace HomeBudgetApp.Application.UseCases.Expenses.Notifications
{
    public record ExpenseUpdatedNotification(Expense oldExpense, decimal updatedAmount, string comment) : INotification;
    public class ExpenseUpdatedNotificationHandler : INotificationHandler<ExpenseUpdatedNotification>
    {
        public Task Handle(ExpenseUpdatedNotification notification, CancellationToken cancellationToken)
        {

            Log.Information($"HomeBudget: Update Expense notification " + $"Actual Expense: Comment: {notification.oldExpense.Comment} Amount: {notification.oldExpense.Amount} \n + $\"Updated Expense: Comment: {notification.comment} Amount: {notification.updatedAmount}");


            return Task.CompletedTask;
        }
    }
}
