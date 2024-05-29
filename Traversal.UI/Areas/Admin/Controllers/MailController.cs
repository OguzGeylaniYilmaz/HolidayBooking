using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal.UI.Areas.Admin.Models;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new();
            MailboxAddress mailboxAddressFrom = new(mailRequest.Name,mailRequest.SenderMail);

            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new("User", mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new();
            smtpClient.Connect("smtp.gmail.com",587,false);
            //smtpClient.Authenticate();
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
