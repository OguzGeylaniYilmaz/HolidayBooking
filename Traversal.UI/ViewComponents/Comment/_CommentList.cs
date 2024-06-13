using BusinessLayer.Concrete;
using DataAccessLayer.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var valueId = commentManager.GetCommentListWithUser(id);
            return View(valueId);
        }
    }
}
