using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Dashboard
{
    public class _PlatformSettings : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
