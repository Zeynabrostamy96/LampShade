

using _01_Query.Contract.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServciceHost.ViewComponents
{
    public class LatestArticlesViewComponent :ViewComponent
    {
        private readonly IArticleQuery _articleQuery;
        public LatestArticlesViewComponent (IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }
        public IViewComponentResult Invoke()
        {
            var result = _articleQuery.LatestArticles();
            return View(result);
        }
    }
}
