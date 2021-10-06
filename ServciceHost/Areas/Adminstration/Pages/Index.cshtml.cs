
using _01_Farmework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServciceHost.Areas.Adminstration.Pages
{
    //[Authorize(Roles =Roles.Adminstrator)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
