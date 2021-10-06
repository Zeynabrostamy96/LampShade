using _01_Query.Contract.Product;
using System.Collections.Generic;
using ShopManagement.Domain.ProductAgg;


namespace _01_Query.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryViewModel> GetList();
        List<ProductCategoryViewModel> GetCategoryProductWhitProducts();
        ProductCategoryViewModel GetCategoryProductWhitProducts(string slug);
    }
}
