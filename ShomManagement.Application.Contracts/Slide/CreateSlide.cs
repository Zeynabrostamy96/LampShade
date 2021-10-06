using _01_Farmework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Heading { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Title { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Text { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string BtnText { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Link { get; set; }
    }
}
