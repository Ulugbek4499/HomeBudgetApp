using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetApp.MVC.UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ApiBaseController : Controller
    {
        private IMediator? _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected IWebHostEnvironment _hostEnviroment
       => HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();
    }
}
