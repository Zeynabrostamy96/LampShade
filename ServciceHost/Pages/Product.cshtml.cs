using _01_Query.Contract.Product;
using CommentManagment.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServciceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        public ProductModel(IProductQuery productQuery,ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }
        public ProductViewModel  product { get; set; }
        public void OnGet(string slug )
        {
            product = _productQuery.GetDetailsby(slug);
        }
        public IActionResult OnPost(AddComment command,string ProductSlug)
        {
            command.Type = CommentType.Product;
            _commentApplication.Add(command);
            return RedirectToPage("./Product", new { id = ProductSlug });
            
        }
    }
}
