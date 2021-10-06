

using _01_Farmework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagment.Application.contract.ArticleCategory
{
    public  class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Name { get; set; }

        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string ShowOrder { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string MetaDesCription { get; set; }
        public string CanonicalAddress { get; set; }
    }
}
