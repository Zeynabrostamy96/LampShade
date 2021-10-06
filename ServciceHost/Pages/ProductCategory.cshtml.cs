using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServciceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }
        public ProductCategoryViewModel ProductCategory { get; set; }
        public void OnGet(string slug)
        {
            ProductCategory = _productCategoryQuery.GetCategoryProductWhitProducts(slug);
        }
    }
}
