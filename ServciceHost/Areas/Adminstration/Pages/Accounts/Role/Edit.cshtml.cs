using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagment.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServciceHost.Areas.Adminstration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public EditModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
        public EditRole command { get; set; }
        public void OnGet(long id)
        {
         command= _roleApplication.GetDetails(id);
         
        }
        public IActionResult OnPost(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
