using _01_Farmework.Application;
using _01_Query.Contract.Article;
using _01_Query.Contract.Comment;
using BlogManagement.Infrastructure;
using CommentManagment.Application.Contracts.Comment;
using CommentManagment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _01_Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;
        public ArticleQuery(BlogContext blogContext,CommentContext commentContext )
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public ArticleQueryView GetArticleDetails(string slug)
        {
 
            var article= _blogContext.Articles
                  .Include(x => x.articleCategory)
                  .Select(x => new ArticleQueryView
                  {
                      id = x.id,
                      Title = x.Title,
                      Description = x.Description,
                      ShortDescription = x.ShortDescription,
                      Slug = x.Slug,
                      CategorySlug = x.articleCategory.Slug,
                      AricleCategoryId = x.articleCategory.id,
                      CanonicalAddres = x.CanonicalAddres,
                      CategoryName = x.articleCategory.Name,
                      KeyWords = x.KeyWords,
                      MetaDescription = x.MetaDescription,
                      Picture = x.Picture,
                      PictureAlt = x.PictureAlt,
                      PictureTitle = x.PictureTitle,
                      PublishDate = x.PublishDate.ToFarsi()
                  }).FirstOrDefault(x => x.Slug == slug);
            article.keywords = article.KeyWords.Split(",").ToList();
          var comments = _commentContext.comments
                .Where(x => !x.ISConceled && x.ISConfiremed)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.id)
               
                .Select(x => new CommentQueryViewModel
                {
                    id = x.id,
                    Name = x.Name,
                    Email = x.Email,
                    Website = x.Website,
                    Message = x.Message,
                    CreationDate = x.Crationdate.ToFarsi(),
                    Parentid=x.ParentId,

                }
                ).OrderByDescending(x=>x.id).ToList();
            foreach(var commment in comments)
            {
                if (commment.Parentid > 0)
                {
                    commment.ParentName = comments.FirstOrDefault(x => x.id == commment.Parentid)?.Name;
                }
            }
            article.comments = comments;
            return article;
        }

        public List<ArticleQueryView> LatestArticles()
        {
            return _blogContext.Articles
                .Include(x => x.articleCategory)
                .Where(x => x.PublishDate <= DateTime.Now).Select(x =>
                new ArticleQueryView
                {
                    id = x.id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Slug = x.Slug,
                    CategorySlug = x.articleCategory.Slug,
                    AricleCategoryId = x.articleCategory.id,
                    CategoryName = x.articleCategory.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi()


                }).ToList();
            
        }
    }
}
