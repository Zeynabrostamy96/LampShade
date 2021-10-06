﻿using _01_Farmework;
using System;


namespace DiscountManagment.Domain.CustomerDiscountAgg
{
    public   class CustomerDiscount:EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }
     
        public CustomerDiscount()
        {

        }
        public CustomerDiscount(long productid,int discountrate,DateTime  startdate, DateTime enddate,string reason)
        {
            ProductId = productid;
            DiscountRate = discountrate;
            StartDate = startdate;
            EndDate = enddate;
            Reason = reason;

        }
        public void Edit(long productid, int discountrate, DateTime startdate, DateTime enddate, string reason)
        {
            ProductId = productid;
            DiscountRate = discountrate;
            StartDate = startdate;
            EndDate = enddate;
            Reason = reason;

        }

    }
}
