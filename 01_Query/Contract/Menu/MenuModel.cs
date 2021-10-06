using _01_Query.Contract.ArticleCategory;
using _01_Query.Contract.ProductCategory;
using System.Collections.Generic;

namespace _01_Query.Contract.Menu
{
    public class MenuModel
    {
        public List<ArticleCategoryViewModel> articleCategories { get; set; }
        public List<ProductCategoryViewModel> productCategories { get; set; }
    }
}
