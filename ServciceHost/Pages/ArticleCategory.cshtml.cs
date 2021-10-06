using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServciceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        private readonly IArticleCategoryQuery _articleCategory;
        private readonly IArticleQuery _articleQuery;
        public ArticleCategoryModel(IArticleCategoryQuery articleCategory,IArticleQuery articleQuery)
        {
            _articleCategory = articleCategory;
            _articleQuery = articleQuery;
        }
        public ArticleCategoryViewModel  articleCategory { get; set; }
        public List<ArticleCategoryViewModel> articleCategories { get; set; }
        public List<ArticleQueryView> LatestArticles { get; set; }
        public void OnGet(string slug)
        {
            articleCategory = _articleCategory.GetArticleCategoryBy(slug);
            articleCategories = _articleCategory.GetArticleCategories();
            LatestArticles = _articleQuery.LatestArticles();
        }
    }
}
