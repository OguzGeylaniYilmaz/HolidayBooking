using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using Traversal.UI.Models;

namespace Traversal.UI.Controllers
{
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new();

            MailboxAddress mailboxAddressFrom = new("Admin", "example@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);


            MailboxAddress mailboxAddressTo = new("User", viewModel.Mail);
            mimeMessage.From.Add(mailboxAddressTo); 

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;

            mimeMessage.Subject = "Password Change Request";

            SmtpClient client = new();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("example@gmail.com", "tokencomeshere");
            client.Send(mimeMessage);
            client.Disconnect(true);


            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId,string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];


            var user =  await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ResetPasswordAsync(user,token.ToString(),viewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
