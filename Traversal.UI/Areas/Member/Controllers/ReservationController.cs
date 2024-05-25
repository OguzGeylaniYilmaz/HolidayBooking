using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EfCore;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traversal.UI.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IDestinationDal _destinationDal;
        private readonly IReservationDal _reservationDal;
        private readonly UserManager<AppUser> _userManager;
        ReservationManager reservationManager=new(new EfReservationDal());

        public ReservationController(IDestinationDal destinationDal, IReservationDal reservationDal, 
            UserManager<AppUser> userManager)
        {
            _destinationDal = destinationDal;
            _reservationDal = reservationDal;
            _userManager = userManager;
        }

        public async  Task<IActionResult> CurrentReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = reservationManager.GetApprovedReservations(user.Id);
            return View(userId);
        }
        public async Task<IActionResult> PreviousReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = reservationManager.GetPreviousReservations(user.Id);
            return View(userId);
        }

        public async Task<IActionResult> AwaitingApprovals()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = reservationManager.GetAwaitingReservations(user.Id);
            return View(userId);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationDal.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();

            ViewBag.data = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserId = 1;
            reservation.Status = "Waiting Approvel";
            _reservationDal.Insert(reservation);
            return RedirectToAction("CurrentReservations");
        }
    }
}
