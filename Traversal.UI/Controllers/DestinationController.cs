using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var detaildId = destinationManager.GetById(id);
            return View(detaildId);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}
