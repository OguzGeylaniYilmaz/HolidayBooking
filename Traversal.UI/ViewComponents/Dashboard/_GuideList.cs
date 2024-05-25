using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Dashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager guideManager = new(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = guideManager.GetAll();
            return View(values);
        }
    }
}
