

using System;

namespace DiscountManagement.DM_Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {
        public long  ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
    }
}
