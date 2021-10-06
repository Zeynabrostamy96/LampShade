using _01_Farmework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public  class CreateProductPicture
    {
        [Range(0,10000000,ErrorMessage = ValidationMessage.IsRequierd)]
        public long ProductId { get;set; }

        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ApplicationMessage.MaxFileSize)]
        public IFormFile Picture { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string PictureTitle { get; set; }

        public List<ProductViewModel> products { get; set; }

    }
}
