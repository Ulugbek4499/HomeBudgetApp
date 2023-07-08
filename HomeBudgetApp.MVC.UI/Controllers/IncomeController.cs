using HomeBudgetApp.Application.Commons.Models;
using HomeBudgetApp.Application.UseCases.Incomes.Commands.CreateIncomes;
using HomeBudgetApp.Application.UseCases.Incomes.Commands.UpdateIncomes;
using HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncome;
using HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncomes;
using Microsoft.AspNetCore.Mvc;
using HomeBudgetApp.Application.UseCases.Incomes.Commands.DeleteIncomes;
using HomeBudgetApp.Application.UseCases.Expenses.Queries.GetExpensesByCategory;
using HomeBudgetApp.Application.UseCases.Incomes.Queries.GetIncomesByCategory;

namespace HomeBudgetApp.MVC.UI.Controllers
{
    public class IncomeController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateIncome()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateIncome([FromForm] CreateIncomeCommand Income)
        {
            await Mediator.Send(Income);

            return RedirectToAction("GetAllIncomes");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateIncome(Guid Id)
        {
            var Income = await Mediator.Send(new GetIncomeQuery(Id));

            return View(Income);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateIncome([FromForm] UpdateIncomeCommand Income)
        {
            await Mediator.Send(Income);
            return RedirectToAction("GetAllIncomes");
        }

        public async ValueTask<IActionResult> DeleteIncome(Guid Id)
        {
            await Mediator.Send(new DeleteIncomeCommand(Id));

            return RedirectToAction("GetAllIncomes");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllIncomes()
        {
            IncomeDto[] Incomes = await Mediator.Send(new GetIncomesQuery());

            return View(Incomes);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewIncome(Guid id)
        {
            var Income = await Mediator.Send(new GetIncomeQuery(id));

            return View("ViewIncome", Income);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ShowDataInCharts()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<List<object>> GetDataInCharts()
        {
            List<object> data = await Mediator.Send(new GetIncomesByCategoryQuery());

            return data;
        }
    }
}
