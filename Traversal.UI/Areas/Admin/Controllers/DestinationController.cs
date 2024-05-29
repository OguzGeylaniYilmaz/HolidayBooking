using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values =_destinationService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.Add(destination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var editedId = _destinationService.GetById(id);
            return View(editedId);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.Edit(destination);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        public IActionResult DeleteDestination(int id)
        {
            var deletedId = _destinationService.GetById(id);
            _destinationService.Remove(deletedId);
            return RedirectToAction("Index");
        }
    }
}
