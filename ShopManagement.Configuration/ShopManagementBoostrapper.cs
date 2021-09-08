
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShomManagement.Application.Contracts.Productctaegory;
using ShopManagement.Application.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Configuration
{
    public class ShopManagementBoostrapper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IproductCategoryApplication, ProductCategoryApplication>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
