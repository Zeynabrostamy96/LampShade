
using _01_Query.Contract.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServciceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;
        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }
        public IViewComponentResult Invoke()
        {
            var query = _slideQuery.GetSlides();
            return View( query);
      
        }
    }
}
