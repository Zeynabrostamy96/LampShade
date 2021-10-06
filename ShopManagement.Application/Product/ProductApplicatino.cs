
using _0_Framework.Application;
using _01_Farmework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application.Product
{
    public class ProductApplicatino: IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductApplicatino(IProductRepository productRepository,IFileUploader fileUploader,IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name ))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);


            var slug = command.Slug.Slugify();
            var slugcategory = _productCategoryRepository.GetSlugCategoryby(command.ProductegoryId);
            var productpath = $"{slugcategory}//{slug}";
            var filename = _fileUploader.Upload(command.Picture, productpath);
            var product = new ShopManagement.Domain.ProductAgg.Product(command.Name,command.Description,
                command.ShortDescription
                , slug, command.KeyWords,command.MetaDescription, filename, command.PictureTitle
                ,command.PictureAlt,command.Code,command.ProductegoryId);
            _productRepository.Create(product);
            _productRepository.Save();
            return operation.Succedded();
            
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.id);
            if (product == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.id!=command.id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var slugcategory = _productCategoryRepository.GetSlugCategoryby(command.ProductegoryId);
            var productpath = $"{slugcategory}/{slug}";
            var filename = _fileUploader.Upload(command.Picture, productpath);
            product.Edit(command.Name, command.Description,
                command.ShortDescription
                , slug, command.KeyWords, command.MetaDescription, filename, command.PictureTitle
                , command.PictureAlt, command.Code, command.ProductegoryId);
            _productRepository.Save();
            return operation.Succedded();


        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetList()
        {
            return _productRepository.GetList();
        }

       

     

        public List<ProductViewModel> Search(ProductSearchModel productSearch)
        {
            return _productRepository.Search(productSearch);
        }
    }
}
