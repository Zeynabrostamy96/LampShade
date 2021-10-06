

using _01_Farmework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagment.Application.contract.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Title { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string ShortDescription { get;  set; }

        public string Description { get;  set; }

        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PictureTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Slug { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string KeyWords { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string MetaDescription { get;  set; }
        public string CanonicalAddres { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PublishDate { get;  set; }
        [Range(1,long.MaxValue,ErrorMessage =ValidationMessage.IsRequierd)]
        public long AricleCategoryId { get;  set; }

    }
}
