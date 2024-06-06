using Microsoft.AspNetCore.Mvc;
using Traversal.UI.CQRS.Commands.DestinationCommands;
using Traversal.UI.CQRS.Handlers.DestinationHandlers;
using Traversal.UI.CQRS.Queries.DestinationQueries;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CQRSController : Controller
    {
        private readonly GetDestinationsQueryHandler _queryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdHandler;
        private readonly CreateDestinationCommandHandler _createDestinationHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationHandler;

        public CQRSController(GetDestinationsQueryHandler queryHandler, GetDestinationByIdQueryHandler getDestinationByIdHandler,
            CreateDestinationCommandHandler createDestinationHandler, RemoveDestinationCommandHandler removeDestinationHandler, UpdateDestinationCommandHandler updateDestinationHandler)
        {
            _queryHandler = queryHandler;
            _getDestinationByIdHandler = getDestinationByIdHandler;
            _createDestinationHandler = createDestinationHandler;
            _removeDestinationHandler = removeDestinationHandler;
            _updateDestinationHandler = updateDestinationHandler;
        }

        public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIdHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }


    }
}
