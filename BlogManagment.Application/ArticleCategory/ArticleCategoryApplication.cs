using _0_Framework.Application;
using _01_Farmework.Application;
using BlogManagment.Application.contract.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace BlogManagment.Application.ArticleCategory
{
    public class ArticleCategoryApplication: IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = slug;
            var picturename = _fileUploader.Upload(command.Picture, path);

            var articlecategory = new Domain.ArticleCategoryAgg.ArticleCategory(command.Name, picturename, command.PictureAlt
                , command.PictureTitle, command.Description, command.ShowOrder, slug, command.KeyWords, command.MetaDesCription, command.CanonicalAddress
                );
            _articleCategoryRepository.Create(articlecategory);
            _articleCategoryRepository.Save();
          return  operation.Succedded();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
     
            var articlecategory = _articleCategoryRepository.Get(command.id);
            if (articlecategory == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.id != command.id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = slug;
            var picturename = _fileUploader.Upload(command.Picture, path);
            articlecategory.Edit(command.Name, picturename, command.PictureAlt
                , command.PictureTitle, command.Description, command.ShowOrder, slug, command.KeyWords, command.MetaDesCription, command.CanonicalAddress);

            _articleCategoryRepository.Save();
            return operation.Succedded();

        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            return _articleCategoryRepository.Search(search);
        }
    }
}

