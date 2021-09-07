using _01_Farmework.Application;
using System.Collections.Generic;


namespace ShomManagement.Application.Contracts.Productctaegory
{
    public  interface IproductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel);

    }
}
