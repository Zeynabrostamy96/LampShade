


using System;

namespace DiscountManagement.DM_Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long id { get; set; }
        public long Productid { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string CreationDate { get; set; }
    }
}
