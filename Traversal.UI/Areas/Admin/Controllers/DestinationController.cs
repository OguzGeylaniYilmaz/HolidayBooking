using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.GetAll();
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
            destinationManager.Add(destination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var editedId = destinationManager.GetById(id);
            return View(editedId);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destinationManager.Edit(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var deletedId = destinationManager.GetById(id);
            destinationManager.Remove(deletedId);
            return RedirectToAction("Index");
        }
    }
}
