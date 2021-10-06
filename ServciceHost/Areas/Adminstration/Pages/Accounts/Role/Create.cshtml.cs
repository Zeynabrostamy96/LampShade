using AccountManagment.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServciceHost.Areas.Adminstration.Pages.Accounts.Role
{
    public class CreateModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public CreateModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
        public CreateRole command { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
