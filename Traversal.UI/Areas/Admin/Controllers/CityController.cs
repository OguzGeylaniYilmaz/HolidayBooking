using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCities()
        {
            var jsonValues = JsonConvert.SerializeObject(_destinationService.GetAll());
            return Json(jsonValues);
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.Add(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
    }
}
