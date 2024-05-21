using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Home
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager aboutManager = new(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            return View(aboutManager.GetAll());
        }
    }
}
