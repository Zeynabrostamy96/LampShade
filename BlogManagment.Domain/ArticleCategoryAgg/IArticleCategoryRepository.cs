using _01_Farmework.Domain;
using BlogManagment.Application.contract.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagment.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository: IRepository<long,ArticleCategory>
    {
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search);
        EditArticleCategory GetDetails(long id);
        string GetSlugBy(long id);
        List<ArticleCategoryViewModel> GetArticleCategories();
    }
}
