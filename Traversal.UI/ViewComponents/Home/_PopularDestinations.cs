using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Home
{
    public class _PopularDestinations : ViewComponent
    {
        DestinationManager destinationManager = new(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = destinationManager.GetAll();
            return View(values);
        }
    }
}
