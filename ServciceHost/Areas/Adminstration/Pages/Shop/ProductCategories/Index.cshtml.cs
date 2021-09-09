
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Productctaegory;
using System;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IproductCategoryApplication _productCategoryApplication;
        public IndexModel(IproductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public List<ProductCategoryViewModel> productCategories { get; set; }
        public ProductCategoryShearchModel shearchModel { get; set; }
        public void OnGet(ProductCategoryShearchModel shearchModel)
        {
            productCategories = _productCategoryApplication.Search(shearchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            if (!ModelState.IsValid)
            {

            }
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
           var product=  _productCategoryApplication.GetDetails(id);
            return Partial("Edit",product);
        }
        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (!ModelState.IsValid)
            {

            }
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
