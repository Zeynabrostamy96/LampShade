using AccountManagment.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServciceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        [TempData]
        public string Message { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }

        [TempData]
        public string SuccessMasssage { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPostLogin(Login command)
        {
            var result=  _accountApplication.Login(command);
            if(result.IsSuccedded)
           
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Account");
        }


        public IActionResult LogOut()
        {
            _accountApplication.LogOute();
            return RedirectToPage("./Index");
        }


        public IActionResult OnPostRegister(RegisterAccount command)
        {
          var result=  _accountApplication.Register(command);
            
            if (result.IsSuccedded)
            {
                SuccessMasssage = "ثبت نام شما با موفقیت انجام شد";
                return RedirectToPage("./Account");
                 
            }
            RegisterMessage = result.Message;

            return RedirectToPage("./Account");
        }
    }
}
