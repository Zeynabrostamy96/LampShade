using ShomManagement.Application.Contracts.Productctaegory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Infrastructure.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;
        public ProductCategoryRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public void Create(ProductCategory entity)
        {
            _shopContext.ProductCategories.Add(entity);
            Save();
            
        }

        public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        {
            return _shopContext.ProductCategories.Any(expression);
        }

        public ProductCategory Get(long id)
        {
            //by find(id)
            return _shopContext.ProductCategories.FirstOrDefault(x => x.id == id);
        }

        public List<ProductCategory> GetAll()
        {
            return _shopContext.ProductCategories.ToList();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _shopContext.ProductCategories.Select(x => new EditProductCategory
            {
                id = x.id,
                Name = x.Name,
                Description = x.Description,
                KeyWords = x.KeyWords,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Picture = x.Picture,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.id == id);
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel)
        {
            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Name = x.Name,
                Crationdate = x.Crationdate.ToString(),
                id = x.id,
                Picture = x.Picture,

            });
            if (!string.IsNullOrWhiteSpace(shearchModel.Name))
                query = query.Where(x => x.Name.Contains(shearchModel.Name));
            return query.OrderByDescending(x => x.id).ToList();
          
            
            
        }
    }
}
