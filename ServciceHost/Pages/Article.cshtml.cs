using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using CommentManagment.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServciceHost.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        public ArticleModel(IArticleQuery articleQuery,IArticleCategoryQuery articleCategoryQuery,ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentApplication = commentApplication;
        }
        public ArticleQueryView article { get; set; }
        public List<ArticleQueryView> LatestArticles { get; set; }
        public List<ArticleCategoryViewModel > articleCategories { get; set; }
        public AddComment command { get; set; }
        public void OnGet(string Slug)
        {
            article = _articleQuery.GetArticleDetails(Slug);
            LatestArticles = _articleQuery.LatestArticles();
            articleCategories = _articleCategoryQuery.GetArticleCategories();

        }
        public IActionResult  OnPost(AddComment command,string articleslug)
        {
            command.Type = CommentType.Article;
            _commentApplication.Add(command);
            return RedirectToPage("/Article", new { id = articleslug });

        }
      
    }
}
