

using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1,100000, ErrorMessage = ValidationMessage.IsRequierd)]
        public long productid { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequierd)]
        public double unitprice { get; set; }
        public List<ProductViewModel> products { get; set; }

    }
}
