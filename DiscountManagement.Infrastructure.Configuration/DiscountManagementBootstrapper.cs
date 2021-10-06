
using DiscountManagement.Application.Contracts.Colleague;
using DiscountManagement.DM_Application.CollegueDiscount;
using DiscountManagement.DM_Application.Contracts.CustomerDiscount;
using DiscountManagement.DM_Application.CustomerDiscount;
using DiscountManagement.Infrastructure.Repository;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Infrastructure.Configuration
{
    public  class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddTransient<ICollegueDiscountApplication, CollegueDiscountApplicatino>();
            services.AddTransient<IColleagueDiscountRepository, CollegueDiscountRepository>();




            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
