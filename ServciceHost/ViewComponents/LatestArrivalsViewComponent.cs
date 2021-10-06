using _01_Query.Contract.Product;

using Microsoft.AspNetCore.Mvc;

namespace ServciceHost.ViewComponents
{
    public class LatestArrivalsViewComponent:ViewComponent
    {
        private readonly IProductQuery _productQuery;
        public LatestArrivalsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public IViewComponentResult Invoke()
        {
            var result = _productQuery.GetLastArrivals();
            return View(result);
        }
    }
}
