using _0_Framework.Application;
using _01_Farmework.Application;
using BlogManagment.Application.contract.Article;
using BlogManagment.Domain.ArticleAgg;
using BlogManagment.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace BlogManagment.Application.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleApplication(IArticleRepository articleRepository,IFileUploader fileUploader,IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = $"{_articleCategoryRepository.GetSlugBy(command.AricleCategoryId)}//{slug}";
            var picturename = _fileUploader.Upload(command.Picture, path);
            var publish = command.PublishDate.ToGeorgianDateTime();

            var article = new Domain.ArticleAgg.Article(command.Title,command.ShortDescription,
                command.Description, picturename, command.PictureTitle,command.PictureAlt, slug, command.KeyWords,command.MetaDescription
                ,command.CanonicalAddres,command.AricleCategoryId, publish);

            _articleRepository.Create(article);
            _articleRepository.Save();
            return operation.Succedded();
            
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.GetWithCategory(command.id);
            if (article == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_articleRepository.Exists(x => x.Title == command.Title && x.id != command.id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var path = $"{article.articleCategory.Slug}//{slug}";
            var picturename = _fileUploader.Upload(command.Picture, path);
            var publish = command.PublishDate.ToGeorgianDateTime();
            article.Edit(command.Title, command.ShortDescription,
                command.Description, picturename, command.PictureTitle, command.PictureAlt, slug, command.KeyWords, command.MetaDescription
                , command.CanonicalAddres, command.AricleCategoryId, publish);
          
            _articleRepository.Save();
            return operation.Succedded();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }



        public List<ArticleViewModel> Search(ArticleSaerchModel saerchModel)
        {
            return _articleRepository.Search(saerchModel);
        }
    }
}
