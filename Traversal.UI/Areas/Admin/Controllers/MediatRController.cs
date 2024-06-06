using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.UI.CQRS.Commands.GuideCommands;
using Traversal.UI.CQRS.Queries.GuideQueries;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MediatRController : Controller
    {
        private readonly IMediator _mediator;

        public MediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetGuidesQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var value = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(value);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
