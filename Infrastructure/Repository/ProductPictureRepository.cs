using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ProductPictureRepository: RepositoryBase<long,ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;
        public ProductPictureRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _shopContext.productPictures.Select(x => new EditProductPicture
            {
                id=x.id,
      
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                ProductId=x.ProductId,
                
            }).FirstOrDefault(x => x.id == id);



        }

        public ProductPicture GetProductandCategory(long id)
        {
            return _shopContext.productPictures.Include(x => x.product).ThenInclude(x => x.productCategory).FirstOrDefault(x => x.id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _shopContext.productPictures.Include(x=>x.product).Select(x => new ProductPictureViewModel
            {
                id=x.id,
                Picture=x.Picture,
                CreationDate=x.Crationdate.ToFarsi(),
                Product=x.product.Name,
                IsRemoved=x.IsRemove,
            });
            if (searchModel.ProductId != 0)
                query = query.Where(x => x.Productid == searchModel.ProductId);
            return query.ToList();


        }
    }
}
