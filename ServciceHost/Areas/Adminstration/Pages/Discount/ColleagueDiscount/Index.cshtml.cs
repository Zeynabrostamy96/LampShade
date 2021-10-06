
using DiscountManagement.Application.Contracts.Colleague;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Discount.ColleageDiscount
{
    public class IndexModel : PageModel
    {
        private readonly ICollegueDiscountApplication _collegueDiscountApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(ICollegueDiscountApplication collegueDiscountApplication, IProductApplication productApplication)
        {
            _collegueDiscountApplication = collegueDiscountApplication;
            _productApplication = productApplication;
        }
        public List<CollegueDiscountViewModel> collegueDiscount { get; set; }
        public CollegueDiscountSearchModel searchmodel { get; set; }
        public SelectList Products { get; set; }
        public void OnGet(CollegueDiscountSearchModel searchmodel)
        {
            Products = new SelectList(_productApplication.GetList(), "id", "Name");
            collegueDiscount = _collegueDiscountApplication.Search(searchmodel);
  

        }
        public IActionResult OnGetCreate()
        {
            var discount = new DefineColleagueDiscount()
            {
                products = _productApplication.GetList()

            };

 
            return Partial("./Create",discount);
        }
        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _collegueDiscountApplication.Define(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {

            var dicount = _collegueDiscountApplication.GetDetails(id);
            dicount.products = _productApplication.GetList();

            return Partial("Edit", dicount);
        }
        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _collegueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
          var result=  _collegueDiscountApplication.Remove(id);

            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _collegueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }


    }
}
