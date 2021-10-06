using _01_Farmework.Domain;
using BlogManagment.Application.contract.Article;
using System.Collections.Generic;

namespace BlogManagment.Domain.ArticleAgg
{
    public  interface IArticleRepository:IRepository<long, Article>
    {
        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSaerchModel saerchModel);
        Article GetWithCategory(long id);
    }
}
