

using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Infrastructure.Repository;
using InventoryManagment.Application.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastructure.Configuration
{
    public  class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection  services,string ConectionString)
        {
            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddDbContext<InventoryContext>(x=>x.UseSqlServer(ConectionString));

        }
    }
}
