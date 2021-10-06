

using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using _01_Query.Query;
using BlogManagement.Infrastructure;
using BlogManagement.Infrastructure.Rropository;
using BlogManagment.Application.Article;
using BlogManagment.Application.ArticleCategory;
using BlogManagment.Application.contract.Article;
using BlogManagment.Application.contract.ArticleCategory;
using BlogManagment.Domain.ArticleAgg;
using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagment.Infrastructure.Configuration
{
   public  class BlogManagementBootstraper
   {
        public static void Configure(IServiceCollection services,string ConnectionString)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            services.AddTransient < IArticleApplication,ArticleApplication >();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();


            services.AddDbContext<BlogContext>(x=>x.UseSqlServer(ConnectionString));

        }


   }
}
