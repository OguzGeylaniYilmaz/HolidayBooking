using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class GuideController : Controller
	{
		private readonly IGuideService _guideService;

		public GuideController(IGuideService guideService)
		{
			_guideService = guideService;
		}

		public IActionResult Index()
		{
			var values = _guideService.GetAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddGuide()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddGuide(Guide guide)
		{
			guide.Status = true;
			_guideService.Add(guide);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditGuide(int id)
		{
			var editedId = _guideService.GetById(id);
			return View(editedId);
		}

		[HttpPost]
        public IActionResult EditGuide(Guide guide)
		{
			guide.Status = true;
			_guideService.Edit(guide);
			return RedirectToAction("Index");
		}

    }
}
