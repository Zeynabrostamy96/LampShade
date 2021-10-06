using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using BlogManagment.Application.contract.Article;
using BlogManagment.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastructure.Rropository
{
    public  class ArticleRepository: RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;
 
        public ArticleRepository(BlogContext blogContext):base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles.Select(x => new EditArticle
            {
                id=x.id,
                ShortDescription=x.ShortDescription,
                Slug=x.Slug,
                AricleCategoryId=x.AricleCategoryId,
                CanonicalAddres=x.CanonicalAddres,
                Description=x.Description,
                KeyWords=x.KeyWords,
                MetaDescription=x.MetaDescription,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                PublishDate=x.PublishDate.ToFarsi(),
                Title=x.Title,
                

            }).FirstOrDefault(x => x.id == id);
        }

        public Article GetWithCategory(long id)
        {
            return _blogContext.Articles.Include(x => x.articleCategory).FirstOrDefault(x => x.id == id);
        }

        public List<ArticleViewModel> Search(ArticleSaerchModel saerchModel)
        {
            var query = _blogContext.Articles.Include(x=>x.articleCategory).Select(x => new ArticleViewModel
            {
                id=x.id,
                ArticleCategoryName=x.articleCategory.Name,
                ShortDescription=x.ShortDescription.Substring(0,Math.Min(x.ShortDescription.Length,50))+"...",
                Picture=x.Picture,
                PublishDate=x.PublishDate.ToFarsi(),
                ArticleCategoryId=x.AricleCategoryId,
                Title=x.Title,
            });

            if (!string.IsNullOrWhiteSpace(saerchModel.Title))
                query = query.Where(x => x.Title.Contains(saerchModel.Title));
            if (saerchModel.CategoryId != 0)
                query = query.Where(x => x.ArticleCategoryId == saerchModel.CategoryId);
                return query.OrderByDescending(x=>x.id).ToList();
        }
    }
}
