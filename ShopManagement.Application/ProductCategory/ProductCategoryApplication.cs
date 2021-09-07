using _0_Framework.Application;
using _01_Farmework.Application;
using ShomManagement.Application.Contracts.Productctaegory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application.ProductCategory
{
    public class ProductCategoryApplication : IproductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
          
              return  operation.Faild(". رکورد تکراری ثبت نمی شود");

            var slug = command.Slug.Slugify();
            var productCategory = new Domain.ProductCategoryAgg.ProductCategory(command.Name, command.Description, command.Picture, command.PictureTitle, command.PictureAlt, command.KeyWords, command.MetaDescription, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productcategory = _productCategoryRepository.Get(command.id);
            if (productcategory==null)
                return operation.Faild("این رکورد با اطلاعات در خواست شده یافت نشد.");
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name && x.id!= command.id))
                return operation.Faild(". رکورد تکراری ثبت نمی شود");
           
            var slug = command.Slug.Slugify();
            productcategory.Edit(command.Name, command.Description, command.Picture, command.PictureTitle, command.PictureAlt, command.KeyWords, command.MetaDescription, slug);
            _productCategoryRepository.Save();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel)
        {
            return _productCategoryRepository.Search(shearchModel);
        }

      
    }
}