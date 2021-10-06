
using AccountManagment.Application.Contracts.Account;
using AccountManagment.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        public IndexModel(IAccountApplication accountApplication,IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;

        }
        public List<AccountViewModel> accounts { get; set; }
        public AccountSearchModel shearchModel { get; set; }
        public EditAccount  edit { get; set; }
        public SelectList Roles { get; set; }
        public void OnGet(AccountSearchModel shearchModel)
        {
            Roles = new SelectList(_roleApplication.List(),"Id","Name");
            accounts = _accountApplication.Search(shearchModel);
        }
        public IActionResult OnGetCreate()
        {
            var account = new RegisterAccount()
            {
                Roles = _roleApplication.List()
            };   

            return Partial("./Create", account);
        }
        public IActionResult OnPostCreate(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            return new JsonResult(result);
        }
        

        public IActionResult OnGetEdit(long id)
        {
           edit= _accountApplication.GetDetails(id);
            edit.Roles = _roleApplication.List();
            return Partial("./Edit",edit);
        }
        public IActionResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);

            return new JsonResult(result);
        }


        public IActionResult OnGetChangePassword(long id)
        {
            var passwordchange = new changePassword()
            {
                id = id
            };

            return Partial("./ChangePassword", passwordchange);
        }
        public IActionResult OnPostChangePassword(changePassword command)
        {
            var result = _accountApplication.ChangePassword(command);

            return new JsonResult(result);
        }

    }
}
