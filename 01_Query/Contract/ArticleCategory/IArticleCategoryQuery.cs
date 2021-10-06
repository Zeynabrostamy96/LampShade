
using System.Collections.Generic;

namespace _01_Query.Contract.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryViewModel> GetArticleCategories();
        ArticleCategoryViewModel GetArticleCategoryBy(string slug);

    }
}
