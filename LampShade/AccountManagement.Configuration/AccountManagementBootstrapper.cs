using _0_Framework.Application;
using AccountManagement.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastracture.EfCore;
using AccountManagement.Infrastracture.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper                                                               
    {
        public static void Configuration(IServiceCollection services,string connectingstring)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleApplication, RoleApplication>();

            services.AddTransient<IPasswordHasher,PasswordHasher>();

            services.AddDbContext<AccountContext>(s => s.UseSqlServer(connectingstring));
        }
    }
}
