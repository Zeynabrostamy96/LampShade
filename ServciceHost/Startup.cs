using _01_Farmework.Application;
using _01_Framework.Application;
using AccountManagment.Infrastructure.Configuration;
using BlogManagment.Infrastructure.Configuration;
using CommentManagment.Configuration;
using DiscountManagement.Infrastructure.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ServciceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            var connection = Configuration.GetConnectionString("LampShapeDb");
            ShopManagementBoostrapper.Configure(services, connection);
            DiscountManagementBootstrapper.Configure(services, connection);
            InventoryManagementBootstrapper.Configure(services, connection);
            BlogManagementBootstraper.Configure(services, connection);
            CommentManagementBootstrapper.Configure(services, connection);
            AccountManagmentBootstraper.Configure(services, connection);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

            services.AddTransient<IFileUploader, FileUploader>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddTransient<IAuthHelper, AuthHelper>();




            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
               {
                   options.AddPolicy
                    ("AdminArea", builder => builder.RequireRole(new List<string> { Roles.Adminstrator, Roles.CurrentUploader }));

                   options.AddPolicy
                   (
                       "Shop", builder => builder.RequireRole(new List<string> { Roles.Adminstrator})
                    );

                 options.AddPolicy
                 (
                   "Discount", builder => builder.RequireRole(new List<string> { Roles.Adminstrator })
                 );
                   options.AddPolicy
                  (
                  "Account", builder => builder.RequireRole(new List<string> { Roles.Adminstrator })
                   );
                 options.AddPolicy
                (
                "Account", builder => builder.RequireRole(new List<string> { Roles.Adminstrator })
                 );
                 options.AddPolicy
                 (
                  "Inventory", builder => builder.RequireRole(new List<string> { Roles.Adminstrator })
                 );


               });

            services.AddRazorPages().AddRazorPagesOptions(options => 
            { options.Conventions.AuthorizeAreaFolder("Adminstration", "/", "AdminArea");
              options.Conventions.AuthorizeAreaFolder("Adminstration", "/Shop", "Shop");
              options.Conventions.AuthorizeAreaFolder("Adminstration", "/Discount", "Discount");
              options.Conventions.AuthorizeAreaFolder("Adminstration", "/Accounts", "Account");
                options.Conventions.AuthorizeAreaFolder("Adminstration", "/Inventory", "Inventory");
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
