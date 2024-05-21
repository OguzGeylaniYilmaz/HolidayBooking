using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Home
{
    public class _Features : ViewComponent
    {
        FeatureManager featureManager = new(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = featureManager.GetAll();
            return View(values);
        }
    }
}
