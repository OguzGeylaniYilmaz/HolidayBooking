using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Home
{
    public class _Testimonial : ViewComponent
    {
        TestimonialManager manager = new(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.GetAll();
            return View(values);
        }
    }
}
