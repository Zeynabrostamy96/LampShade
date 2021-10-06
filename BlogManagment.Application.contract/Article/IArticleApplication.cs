

using _01_Farmework.Application;
using System.Collections.Generic;

namespace BlogManagment.Application.contract.Article
{
    public  interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSaerchModel saerchModel);





    }
}
