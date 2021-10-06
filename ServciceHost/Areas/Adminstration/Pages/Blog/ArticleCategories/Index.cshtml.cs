using BlogManagment.Application.contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public List<ArticleCategoryViewModel> articleCategories { get; set; }
        public ArticleCategorySearchModel  searchModel { get; set; }
        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            articleCategories = _articleCategoryApplication.Search(searchModel);

        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateArticleCategory());
        }
        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
           var result=  _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
           var result= _articleCategoryApplication.GetDetails(id);
            return Partial("./Edit", result);
        }
        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var result = _articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }




    }
}
