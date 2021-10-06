

using _01_Farmework.Application;
using AccountManagment.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagment.Application.Contracts.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string FullName { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string UseName { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Password { get;  set; }
        [Required(ErrorMessage = ValidationMessage.IsRequierd)]
        public string Mobile { get;  set; }
      
        public IFormFile ProfilePhoto { get;  set; }
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessage.IsRequierd)]
        public long RoleId { get;  set; }
        public List<RoleViewModel>  Roles{ get; set; }
    }
}
