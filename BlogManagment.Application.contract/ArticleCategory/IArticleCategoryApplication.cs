
using _01_Farmework.Application;
using System.Collections.Generic;

namespace BlogManagment.Application.contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search);
        List<ArticleCategoryViewModel> GetArticleCategories();
    }
}
 