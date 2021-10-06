

using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.Colleague
{
    public class DefineColleagueDiscount
    {
        [Range(1,10000,ErrorMessage = ValidationMessage.IsRequierd)]
        public long ProductId { get; set; }
        [Range(1, 99, ErrorMessage = ValidationMessage.IsRequierd)]
        public int  DiscountRate { get; set; }
        public List<ProductViewModel> products { get; set; }
    }
}
