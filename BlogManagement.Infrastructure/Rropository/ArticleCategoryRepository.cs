

using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using BlogManagment.Application.contract.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastructure.Rropository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;
        public ArticleCategoryRepository(BlogContext blogContext):base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _blogContext.ArticleCategories
                .Select(x => new EditArticleCategory
                {
                    id=x.id,
                    ShowOrder=x.ShowOrder,
                    Slug=x.Slug,
                    CanonicalAddress=x.CanonicalAddress,
                    Description=x.Description,
                    KeyWords=x.KeyWords,
                    MetaDesCription=x.MetaDesCription,
                    Name=x.Name,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,

                }).FirstOrDefault(x => x.id == id);
                
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                id=x.id,
                Name=x.Name
            }).ToList();
        }

        public string GetSlugBy(long id)
        {
            return _blogContext.ArticleCategories.Select(x => new { x.id, x.Slug }).FirstOrDefault(x => x.id == id).Slug;

        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            var query = _blogContext.ArticleCategories.Include(x=>x.articles).Select(x => new ArticleCategoryViewModel
            {
                id = x.id,
                Name = x.Name,
                Description = x.Description,
                ShowOrder = x.ShowOrder,
                Picture = x.Picture,
                CrationDate = x.Crationdate.ToFarsi(),
                ArticleCount=x.articles.Count()

            });
            if (!string.IsNullOrWhiteSpace(search.Name))
              query = query.Where(x => x.Name.Contains(search.Name));
            return query.OrderByDescending(x => x.ShowOrder).ToList();

        }
    }
}
