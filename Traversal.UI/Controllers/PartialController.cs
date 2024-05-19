using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Controllers
{
    public class PartialController : Controller
    {
        public PartialViewResult _Head()
        {
            return PartialView();
        }
        public PartialViewResult _Header()
        {
            return PartialView();
        }
        public PartialViewResult _Footer()
        {
            return PartialView();
        }
        public PartialViewResult _Scripts()
        {
            return PartialView();
        }
    
    }
}
