using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Application.UseCases.Expenses.Commands;
using HomeBudgetApp.Application.UseCases.Expenses.Commands.CreateExpenses;
using HomeBudgetApp.Application.UseCases.Expenses.Commands.UpdateExpenses;
using HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpense;
using HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpenses;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetApp.MVC.UI.Controllers
{
    public class ExpenseController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateExpense()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateExpense([FromForm] CreateExpenseCommand Expense)
        {
            await Mediator.Send(Expense);

            return RedirectToAction("GetAllExpenses");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateExpense(Guid Id)
        {
            var Expense = await Mediator.Send(new GetExpenseQuery(Id));

            return View(Expense);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateExpense([FromForm] UpdateExpenseCommand Expense)
        {
            await Mediator.Send(Expense);
            return RedirectToAction("GetAllExpenses");
        }

        public async ValueTask<IActionResult> DeleteExpense(Guid Id)
        {
            await Mediator.Send(new DeleteExpenseCommand(Id));

            return RedirectToAction("GetAllExpenses");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllExpenses()
        {
            ExpenseDto[] Expenses = await Mediator.Send(new GetExpensesQuery());

            return View(Expenses);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewExpense(Guid id)
        {
            var Expense = await Mediator.Send(new GetExpenseQuery(id));

            return View("ViewExpense", Expense);
        }
    }
}
