using _01_Farmework.Domain;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public  interface IProductRepository: IRepository<long, Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel productSearch);
        List<ProductViewModel> GetList();
        Product GetProductWithCategory(long id);
    }
}
