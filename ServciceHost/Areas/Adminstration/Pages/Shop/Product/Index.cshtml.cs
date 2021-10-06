
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.Productctaegory;
using System.Collections.Generic;
using System.Linq;

namespace ServciceHost.Areas.Adminstration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IproductCategoryApplication _productCategoryApplication;
        public IndexModel(IProductApplication productApplication,IproductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }
        public List<ProductViewModel> products { get; set; }
        public ProductSearchModel shearchModel { get; set; }
        public SelectList Category { get; set; }
        public void OnGet(ProductSearchModel shearchModel)
        {
            products = _productApplication.Search(shearchModel);
            Category = new SelectList(_productCategoryApplication.GetList(), "id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
             {
                Categories = _productCategoryApplication.GetList()
             };
            
           
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {

            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetList();

            return Partial("Edit", product);
        }
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
    

    }
}
