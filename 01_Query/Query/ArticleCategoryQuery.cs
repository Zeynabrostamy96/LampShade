using _01_Farmework.Application;
using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using BlogManagement.Infrastructure;
using BlogManagment.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Query.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _blogContext;
        public ArticleCategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _blogContext.ArticleCategories.Include(x => x.articles).Select(x => new ArticleCategoryViewModel
            {
                Name = x.Name,
                Description = x.Description,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                KeyWords = x.KeyWords,
                MetaDesCription = x.MetaDesCription,
                CanonicalAddress = x.CanonicalAddress,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ArticleCount = x.articles.Count
            }).ToList();
        }

        public ArticleCategoryViewModel GetArticleCategoryBy(string slug)
        {
            var articlecategory= _blogContext.ArticleCategories.Include(x => x.articles).Select(x =>
              new ArticleCategoryViewModel
              {
                  Slug=x.Slug,
                  Name=x.Name,
                  KeyWords=x.KeyWords,
                  Picture=x.Picture,
                  PictureTitle=x.PictureTitle,
                  PictureAlt=x.PictureAlt,
                  ArticleCount=x.articles.Count,
                  Description=x.Description,
                  MetaDesCription=x.MetaDesCription,
                  articles=MapArticles(x.articles)
                  
              }).FirstOrDefault(x => x.Slug == slug);
            if (!string.IsNullOrWhiteSpace(articlecategory.KeyWords))
            {
                articlecategory.KeywordList = articlecategory.KeyWords.Split(",").ToList();
            }
            
            return articlecategory;
        }

     
        private  static List<ArticleQueryView> MapArticles(List<Article> articles)
        {
            return articles.Select(x => new ArticleQueryView
            {
                id=x.id,
                Title=x.Title,
                Slug=x.Slug,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                ShortDescription=x.ShortDescription,
                PublishDate=x.PublishDate.ToFarsi()

            }).ToList();
        }
    }
}
