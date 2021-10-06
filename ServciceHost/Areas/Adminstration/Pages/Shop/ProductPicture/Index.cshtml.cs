using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ServciceHost.Areas.Adminstration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {

        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(IProductPictureApplication productPictureApplication,IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;

        }
        [TempData]
        public string Message { get; set; }
        public List<ProductPictureViewModel> pictureViewModels { get; set; }
        public ProductPictureSearchModel PictureSearchModel { get; set; }
        public SelectList products { get; set; }
    
        public void OnGet(ProductPictureSearchModel pictureSearchModel)
        {
            pictureViewModels = _productPictureApplication.Search(pictureSearchModel);
            products = new SelectList(_productApplication.GetList(), "id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture
            {
                products = _productApplication.GetList()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
           var result=  _productPictureApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
           var  editProductPicture=_productPictureApplication.GetDetails(id);

            editProductPicture.products = _productApplication.GetList();

            return Partial("./Edit",editProductPicture);
        }
        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {

            _productPictureApplication.Remove(id);

            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {

            _productPictureApplication.Restore(id);

            return RedirectToPage("./Index");

        }
    }
}
 