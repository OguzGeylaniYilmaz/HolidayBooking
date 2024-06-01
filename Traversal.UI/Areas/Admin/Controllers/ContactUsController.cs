using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.GetAll();
            return View(values);
        }

        public IActionResult DeleteContanct(int id)
        {
            var deletedId = _contactUsService.GetById(id);
            _contactUsService.Remove(deletedId);
            return RedirectToAction("Index");
        }
    }
}
