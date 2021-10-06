using BlogManagment.Application.contract.Article;
using BlogManagment.Application.contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServciceHost.Areas.Adminstration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public SelectList categories { get; set; }
        public CreateArticle  Command { get; set; }
        public void OnGet()
        {
            categories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "id", "Name");
        }
        public IActionResult OnPost(CreateArticle Command)
        {
            _articleApplication.Create(Command);
            return RedirectToPage("./Index");
        }
    }
}
