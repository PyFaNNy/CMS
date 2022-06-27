using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace СMS.Controllers
{
    public class BaseController : Controller
    {
        protected ILogger Logger
        {
            get;
        }

        private IMediator? _mediator;

        protected IMediator Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();

        protected BaseController(ILogger logger)
            : base()
        {
            this.Logger = logger;
        }
    }
}
