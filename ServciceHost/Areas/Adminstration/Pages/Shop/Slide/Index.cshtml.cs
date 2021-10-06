using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;

namespace ServciceHost.Areas.Adminstration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {

        private readonly ISlideApplication _slideApplication;
      
        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }
        public List<SlideViewModel> slides { get; set; }
        public void OnGet()
        {
            slides = _slideApplication.GetList();
        }
        public IActionResult OnGetCreate()
        {
           
            return Partial("./Create",new CreateSlide() );
        }
        public JsonResult OnPostCreate(CreateSlide command)
        {
           var result=  _slideApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
           var  editslide=_slideApplication.GetDetails(id);

            return Partial("./Edit",editslide);
        }
        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {

            _slideApplication.Remove(id);

            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {

            _slideApplication.Restore(id);

            return RedirectToPage("./Index");

        }
    }
}
 