using CommentManagment.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Comment
{
    public class IndexModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }
        public List<CommentViewModel> comments { get; set; }
        public CommentSearchModel  search { get; set; }
        public void OnGet(CommentSearchModel search)
        {
            comments = _commentApplication.Search(search);
        }
        public IActionResult OnGetConfierm(long id )
        {
            _commentApplication.Confirem(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetCanceld(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

    }
}
