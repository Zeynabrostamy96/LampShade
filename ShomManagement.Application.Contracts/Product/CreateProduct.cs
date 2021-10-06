using _01_Farmework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Productctaegory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public  class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessage.IsRequierd)]
        public string Name { get; set; }
        public string Description { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Slug { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string KeyWords { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string MetaDescription { get; set; }
        [MaxFileSize(3*1024*1024,ErrorMessage =ApplicationMessage.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureTitle { get;  set; }
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Code { get;  set; }
        [Range(1,100,ErrorMessage =ValidationMessage.IsRequierd)]
        public long ProductegoryId { get;  set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
