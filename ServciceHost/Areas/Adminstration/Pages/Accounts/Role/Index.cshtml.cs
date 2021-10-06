using System.Collections.Generic;
using AccountManagment.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServciceHost.Areas.Adminstration.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
        public List<RoleViewModel> roles { get; set; }
        public void OnGet()
        {
            roles = _roleApplication.List();
        }
      
       
    }
}
