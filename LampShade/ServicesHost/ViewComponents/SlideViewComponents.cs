using _01_LampShadeQuery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            this.slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = slideQuery.GetSlides();
            return View(result);
        }
    }
}
