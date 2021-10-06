using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServciceHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            var result = _productCategoryQuery.GetList();
            return View(result);
        }
    }
}
