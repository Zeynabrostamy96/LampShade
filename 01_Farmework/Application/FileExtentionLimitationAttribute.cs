using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _01_Farmework.Application
{
    public class FileExtentionLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _validExtention;
        public FileExtentionLimitationAttribute(string[] validExtention)
        {
            _validExtention = validExtention;
        }
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null)
                return true;
            var fileExtention = file.FileName;
            return _validExtention.Contains(fileExtention);
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-FileExtentionLimitation", ErrorMessage);
        }
    }
}
