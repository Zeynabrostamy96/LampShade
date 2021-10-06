using _01_Query.Contract.ArticleCategory;
using _01_Query.Contract.Menu;
using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;


namespace ServciceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery,IArticleCategoryQuery articleCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                articleCategories=_articleCategoryQuery.GetArticleCategories(),
                productCategories=_productCategoryQuery.GetList()

            };
            return View(result);
        }
    }
}
