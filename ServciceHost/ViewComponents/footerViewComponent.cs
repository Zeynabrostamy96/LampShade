

using Microsoft.AspNetCore.Mvc;

namespace ServciceHost.ViewComponents
{
    public class footerViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
