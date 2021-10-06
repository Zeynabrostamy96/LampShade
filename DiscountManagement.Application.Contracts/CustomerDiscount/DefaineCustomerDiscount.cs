
using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.DM_Application.Contracts.CustomerDiscount
{
    public   class DefaineCustomerDiscount
    {
        [Range(1, 1000000, ErrorMessage = ValidationMessage.IsRequierd)]
        public long ProductId { get;  set; }

        [Range(1, 99, ErrorMessage = ValidationMessage.IsRequierd)]
        public int DiscountRate { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string StartDate { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string EndDate { get;  set; }

        public string Reason { get;  set; }

        public List<ProductViewModel> Products{ get; set; }
    }
}
