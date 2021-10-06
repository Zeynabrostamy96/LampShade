using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using DiscountManagement.Application.Contracts.Colleague;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.Repository
{
    public class CollegueDiscountRepository: RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;
        public CollegueDiscountRepository(DiscountContext discountContext,ShopContext shopContext):base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _discountContext.colleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                id=x.id,
                DiscountRate=x.DiscountRate,
                ProductId=x.ProductId

            }).FirstOrDefault(x => x.id == id);
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.id, x.Name }).ToList();
            var query = _discountContext.colleagueDiscounts.Select(x => new CollegueDiscountViewModel
            {
                id = x.id,
                ProductId = x.ProductId,
                CreationDate = x.Crationdate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                IsRemoved=x.IsRemove
 
            }) ;
            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            var discount = query.OrderByDescending(x => x.id).ToList();
            discount.ForEach(x => x.product = products.FirstOrDefault(z => z.id == x.ProductId)?.Name);
            return discount;


        }
    }
}
