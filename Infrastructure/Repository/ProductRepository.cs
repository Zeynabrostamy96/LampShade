using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ProductRepository: RepositoryBase<long, Product>,IProductRepository
    {
        private readonly ShopContext _shopContext;
      
        public ProductRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProduct GetDetails(long id)
        {
            return _shopContext.products.Select(x => new EditProduct()
            {
                id=x.id,
                ProductegoryId=x.ProductegoryId,
                Name=x.Name,
                Description=x.Description,
              
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                MetaDescription=x.MetaDescription,
                Code=x.Code,
                ShortDescription=x.ShortDescription,
                KeyWords=x.KeyWords,
                Slug=x.Slug,
               

            }).FirstOrDefault(x => x.id == id);
        }

        public List<ProductViewModel> GetList()
        {
            return _shopContext.products.Select(x => new ProductViewModel
            {
                id=x.id,
                Name=x.Name,
            }).ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return _shopContext.products.Include(x => x.productCategory).FirstOrDefault(x => x.id==id);
        }

        public List<ProductViewModel> Search(ProductSearchModel productSearch)
        {
            var query = _shopContext.products.Include(x=>x.productCategory).Select(x => new ProductViewModel()
            {
                id=x.id,
                Name=x.Name,
                Code=x.Code,
                CategoryId=x.ProductegoryId,
                Picture=x.Picture,
                ProductCategory=x.productCategory.Name,
                CrationDate=x.Crationdate.ToFarsi(),
            
                
            });
            if (!string.IsNullOrWhiteSpace(productSearch.Name))
                query = query.Where(x => x.Name.Contains(productSearch.Name));

            if (!string.IsNullOrWhiteSpace(productSearch.Code))
                query = query.Where(x => x.Code.Contains(productSearch.Code));

            if (productSearch.CtegoryId != 0)
                query = query.Where(x =>x.CategoryId==productSearch.CtegoryId);

            return query.OrderByDescending(x => x.id).ToList();
        }
    }
}
