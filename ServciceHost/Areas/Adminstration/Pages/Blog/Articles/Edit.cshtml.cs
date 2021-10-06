
using BlogManagment.Application.contract.Article;
using BlogManagment.Application.contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServciceHost.Areas.Adminstration.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public EditArticle  Command { get; set; }
        public SelectList categories { get; set; }
        public void OnGet(long id)
        {
            Command = _articleApplication.GetDetails(id);
            categories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "id", "Name");
        }
        public IActionResult OnPost(EditArticle Command)
        {
            _articleApplication.Edit(Command);
            return RedirectToPage("./Index");
        }
    }
}
