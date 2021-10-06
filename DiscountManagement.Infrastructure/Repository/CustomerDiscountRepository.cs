using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using DiscountManagement.DM_Application.Contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Infrastructure.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;
        public CustomerDiscountRepository(DiscountContext discountContext,ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _discountContext.customerDiscounts.Select(x => new EditCustomerDiscount
            {
                id = x.id,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
                Reason = x.Reason,

            }).FirstOrDefault(x => x.id == id);
        }
        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchmodel)
        {
            var products = _shopContext.products.Select(x => new { x.id, x.Name }).ToList();

            var query = _discountContext.customerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                id = x.id,
                Productid = x.ProductId,
                DiscountRate = x.DiscountRate,                                  
                EndDate = x.EndDate.ToFarsi(),
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                Reason = x.Reason,
                CreationDate = x.Crationdate.ToFarsi(),
            });
            if (searchmodel.ProductId != 0)
                query = query.Where(x => x.Productid == searchmodel.ProductId);
            if (!string.IsNullOrWhiteSpace(searchmodel.StartDate))
            {

                query = query.Where(x => x.StartDateGr > searchmodel.StartDate.ToGeorgianDateTime());
            }
            if (!string.IsNullOrWhiteSpace(searchmodel.EndDate))
            {

                query = query.Where(x => x.EndDateGr > searchmodel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.id).ToList();
            discounts.ForEach(x => x.Product = products.FirstOrDefault(z => z.id == x.Productid)?.Name);
            return discounts;
            
        }
    }
}
