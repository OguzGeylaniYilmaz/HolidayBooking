using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.UI.Models;

namespace Traversal.UI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		public LoginController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel viewModel)
		{

			AppUser user = new AppUser()
			{
				Name = viewModel.Name,
				Surname = viewModel.Surname,
				UserName = viewModel.Username,
				Email = viewModel.Mail,
			};

			if (viewModel.Password.Equals(viewModel.ConfirmPassword))
			{
				var result = await _userManager.CreateAsync(user, viewModel.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");
				}
				else
				{
                    foreach (var error in result.Errors)
                    {
						ModelState.AddModelError("", error.Description);
                    }
                }
			}


			return View(viewModel);
		}

		public IActionResult SignIn()
		{
			return View();
		}
	}
}
