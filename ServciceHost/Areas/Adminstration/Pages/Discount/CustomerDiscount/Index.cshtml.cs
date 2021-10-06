

using DiscountManagement.DM_Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.Productctaegory;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(ICustomerDiscountApplication customerDiscountApplication ,IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }
        public List<CustomerDiscountViewModel> customerDiscounts { get; set; }
        public CustomerDiscountSearchModel searchmodel { get; set; }
        public SelectList Products { get; set; }
        public void OnGet(CustomerDiscountSearchModel searchmodel)
        {
            Products = new SelectList(_productApplication.GetList(), "id", "Name");
            customerDiscounts = _customerDiscountApplication.Search(searchmodel);
  

        }
        public IActionResult OnGetCreate()
        {
            var discount = new DefaineCustomerDiscount()
            {
                Products = _productApplication.GetList()

            };

 
            return Partial("./Create",discount);
        }
        public JsonResult OnPostCreate(DefaineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Defaine(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {

            var dicount = _customerDiscountApplication.GetDetails(id);
            dicount.Products = _productApplication.GetList();

            return Partial("Edit", dicount);
        }
        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
      

    }
}
