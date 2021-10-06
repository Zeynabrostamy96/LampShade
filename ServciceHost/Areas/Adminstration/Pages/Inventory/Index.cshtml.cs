using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ServciceHost.Areas.Adminstration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }
        public List<InventoryViewModel> inventories { get; set; }
        public InventorySearchModel searchmodel { get; set; }
        public SelectList Products { get; set; }
        public void OnGet(InventorySearchModel searchmodel)
        {
            Products = new SelectList(_productApplication.GetList(), "id", "Name");
            inventories =_inventoryApplication.Search(searchmodel);
  

        }
        public IActionResult OnGetCreate()
        {
            var discount = new CreateInventory()
            {
               products = _productApplication.GetList()

            };
            return Partial("./Create",discount);
        }
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {

            var dicount = _inventoryApplication.GetDetails(id);
            dicount.products = _productApplication.GetList();

            return Partial("Edit", dicount);
        }
        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetIncrease(long id)
        {
            var result = new IncreaseInventory()
            {
                Inventoryid = id
            };

            return Partial("Increase",result);
        }
        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetReduce(long id)
        {
            var result = new ReduceInventory()
            {
                Inventoryid = id
            };

            return Partial("Reduce", result);
        }
        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLog(long id )
        {
            //var operation = new InventoryOperationViewModel 
            //{
            //   OperatorId=id
            //};
            var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog",log);
        }

    }
}
