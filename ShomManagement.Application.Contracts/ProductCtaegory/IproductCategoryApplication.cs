using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShomManagement.Application.Contracts.ProductCtaegory
{
    public  interface IproductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        ProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel);

    }
}
