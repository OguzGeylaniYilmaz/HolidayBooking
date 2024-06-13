using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.UI.ViewComponents.Destination
{
    public class _GuideDetails : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var commentId = _guideService.GetById(1);
            return View(commentId);
        }

    }
}
