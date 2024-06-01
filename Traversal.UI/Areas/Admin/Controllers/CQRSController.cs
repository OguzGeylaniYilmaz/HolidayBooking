using Microsoft.AspNetCore.Mvc;
using Traversal.UI.CQRS.Handlers.DestinationHandlers;
using Traversal.UI.CQRS.Queries.DestinationQueries;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CQRSController : Controller
    {
        private readonly GetDestinationsQueryHandler _queryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdHandler;

        public CQRSController(GetDestinationsQueryHandler queryHandler, GetDestinationByIdQueryHandler getDestinationByIdHandler)
        {
            _queryHandler = queryHandler;
            _getDestinationByIdHandler = getDestinationByIdHandler;
        }

        public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        }

        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIdHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }
    }
}
