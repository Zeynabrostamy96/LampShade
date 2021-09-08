using _01_Farmework.Domain;
using ShomManagement.Application.Contracts.Productctaegory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace ShopManagement.Domain.ProductCategoryAgg
{
    public  interface IProductCategoryRepository: IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel);
        
    }
}
