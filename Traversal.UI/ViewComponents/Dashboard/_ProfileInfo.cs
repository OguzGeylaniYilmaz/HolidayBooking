using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal.UI.ViewComponents.Dashboard
{
    public class _ProfileInfo : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInfo(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.username = user.Name + " " + user.Surname;
            ViewBag.email = user.Email;
            
            return View();
        }
    }
}
