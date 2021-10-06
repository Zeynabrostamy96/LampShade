

using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Productctaegory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Application.ProductPicture
{
    public class ProductPictureApplicatin : IProductPictureApplication
    {
        private readonly IProductPictureRepository  _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplicatin(IProductPictureRepository productPictureRepository,IFileUploader fileUploader, IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path =$"{product.productCategory.Slug}//{product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            var picture = new Domain.ProductPictureAgg.ProductPicture(command.ProductId, picturePath,
             command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(picture);
            _productPictureRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(command.id);
            if (productPicture == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            var product = _productPictureRepository.GetProductandCategory(command.id);
            var path = $"{product.product.Slug}//{product.product.productCategory.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
    
            productPicture.Edit(command.ProductId, picturePath,
                command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Save();
            return operation.Succedded();

     
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var picture = _productPictureRepository.Get(id);
            if (picture == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            picture.Remove();
            _productPictureRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var picture = _productPictureRepository.Get(id);
            if (picture == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            picture.Restor();
            _productPictureRepository.Save();
            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
