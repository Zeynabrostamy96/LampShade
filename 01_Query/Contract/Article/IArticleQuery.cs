using System.Collections.Generic;

namespace _01_Query.Contract.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> LatestArticles();
        ArticleQueryView GetArticleDetails(string slug);

    }
}
