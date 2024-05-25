using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class PartialMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult _Head()
        {
            return PartialView();
        }

        public PartialViewResult _Navbar()
        {
            return PartialView();
        }

        public PartialViewResult _Navbar2()
        {
            return PartialView();
        }
        public PartialViewResult _Footer()
        {
            return PartialView();
        }

        public PartialViewResult _RightMenu() { return PartialView(); }
        public PartialViewResult _Scripts() { return PartialView(); }
    }
}
