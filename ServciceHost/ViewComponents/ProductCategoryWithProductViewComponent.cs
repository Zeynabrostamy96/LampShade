using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;


namespace ServciceHost.ViewComponents
{
    public class ProductCategoryWithProductViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductCategoryWithProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {

            var categories = _productCategoryQuery.GetCategoryProductWhitProducts();

            return View(categories);
        }
    }
    
}
