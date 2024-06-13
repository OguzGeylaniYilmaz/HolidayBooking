using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal.UI.Controllers
{

    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = destinationManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public async  Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = user.Id;
            var detaildId = destinationManager.GetById(id);
            return View(detaildId);
        }


    }
}
