using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
