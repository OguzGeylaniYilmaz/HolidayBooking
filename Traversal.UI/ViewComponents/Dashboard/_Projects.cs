using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Dashboard
{
    public class _Projects : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
