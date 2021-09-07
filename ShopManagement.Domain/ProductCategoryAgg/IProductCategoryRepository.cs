using ShomManagement.Application.Contracts.Productctaegory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace ShopManagement.Domain.ProductCategoryAgg
{
    public  interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
        EditProductCategory GetDetails(long id);
        bool Exists(Expression<Func<ProductCategory,bool>>expression );
        List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel);
        void Save();
    }
}
