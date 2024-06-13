using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Traversal.UI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new(new EfCommentDal());


        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.Status = true;;
            commentManager.Add(comment);
            return RedirectToAction("DestinationDetails", "Destination");
        }
    }
}
