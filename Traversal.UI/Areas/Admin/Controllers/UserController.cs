using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var editedId = _appUserService.GetById(id);
            return View(editedId);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser user)
        {
            _appUserService.Edit(user);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int id)
        {
            var editedId = _appUserService.GetById(id);
            _appUserService.Remove(editedId);
            return RedirectToAction("Index");
        }

        public IActionResult UserComment()
        {
            return View();
        }
        public IActionResult UserReservation(int id)
        {
            var value = _reservationService.GetApprovedReservations(id);
            return View(value);
        }
    }
}

