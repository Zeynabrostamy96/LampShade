using BlogManagment.Application.contract.Article;
using BlogManagment.Application.contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public IndexModel(IArticleApplication articleApplication,IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public List<ArticleViewModel> article { get; set; }
        public ArticleSaerchModel saerchModel { get; set; }
        public SelectList categories { get; set; }
        public void OnGet(ArticleSaerchModel saerchModel)
        {
            article = _articleApplication.Search(saerchModel);
            categories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "id", "Name");

        }



    }
}
