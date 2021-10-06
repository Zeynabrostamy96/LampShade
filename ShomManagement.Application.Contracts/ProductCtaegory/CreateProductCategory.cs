

using _01_Farmework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Productctaegory
{
    public  class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessage.Message )]
        public string Name { get;  set; }
        public string Description { get;  set; }

        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ApplicationMessage.MaxFileSize)]
        //[FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "")]
        public IFormFile Picture { get;  set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessage.Message)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessage.Message)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage = ValidationMessage.Message)]
        public string Slug { get;  set; }
    }
}
