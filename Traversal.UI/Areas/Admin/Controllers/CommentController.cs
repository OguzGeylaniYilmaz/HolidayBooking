using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetAllCommentsWithDestinations();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            var deletedId = _commentService.GetById(id);
            _commentService.Remove(deletedId);
            return RedirectToAction("Index");
        }
    }
}
