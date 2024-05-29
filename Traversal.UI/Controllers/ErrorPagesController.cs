using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Controllers
{
    public class ErrorPagesController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
