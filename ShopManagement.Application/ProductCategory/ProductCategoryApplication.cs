using _0_Framework.Application;
using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Productctaegory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application.ProductCategory
{
    public class ProductCategoryApplication : IproductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository,IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;

        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
          
              return  operation.Faild(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var picturepath = $"{command.Slug}";
            var filename = _fileUploader.Upload(command.Picture,picturepath);
            var productCategory = new Domain.ProductCategoryAgg.ProductCategory(command.Name, command.Description, filename, command.PictureTitle, command.PictureAlt, command.KeyWords, command.MetaDescription, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productcategory = _productCategoryRepository.Get(command.id);
            if (productcategory==null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name && x.id!= command.id))
                return operation.Faild(ApplicationMessage.RecordNotFound);
           
            var slug = command.Slug.Slugify();
            var picturepath = $"{command.Slug}";
            var filename = _fileUploader.Upload(command.Picture, picturepath);
            productcategory.Edit(command.Name, command.Description, filename, command.PictureTitle, command.PictureAlt, command.KeyWords, command.MetaDescription, slug);
            _productCategoryRepository.Save();
            return operation.Succedded();
        }

        

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetList()
        {
            return _productCategoryRepository.Getlist();
        }

        public List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel)
        {
            return _productCategoryRepository.Search(shearchModel);
        }

      
    }
}