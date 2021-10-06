

using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagment.Application.Account;
using AccountManagment.Application.Contracts.Account;
using AccountManagment.Application.Contracts.Role;
using AccountManagment.Application.Role;
using AccountManagment.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagment.Infrastructure.Configuration
{
    public class AccountManagmentBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddDbContext<AccountContext>(x=>x.UseSqlServer(connectionString));
        }

    }
}
