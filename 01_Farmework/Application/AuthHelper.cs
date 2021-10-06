using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using _01_Farmework.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;


namespace _01_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var resul = new AuthViewModel();

            if (!IsAuthenticated())
                return resul;
            var climes = _contextAccessor.HttpContext.User.Claims.ToList();
            resul.id = long.Parse(  climes.FirstOrDefault(x => x.Type == "AccountId").Value);
            resul.RoleId = long.Parse(climes.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            resul.FullName = climes.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            resul.UseName = climes.FirstOrDefault(x => x.Type == "Username").Value;
            resul.RoleName = Roles.GetRoleBy(resul.RoleId);
            return resul;


        }

        public string CurrentAcountRole()
        {
            if (IsAuthenticated())
            {
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            }
            return null;
        }

        public bool IsAuthenticated()
        {
            var climes = _contextAccessor.HttpContext.User.Claims.ToList();
            return climes.Count > 0;
        }

        public void Signin(AuthViewModel account)
        {
  
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.id.ToString()),
                new Claim(ClaimTypes.Name, account.FullName),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.UseName), // Or Use ClaimTypes.NameIdentifier
           
                
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
