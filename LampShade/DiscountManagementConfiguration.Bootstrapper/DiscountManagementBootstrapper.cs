using Discount.Management.Domain.ColleagueDiscountAgg;
using Discount.Management.Domain.CoustomDiscountAgg;
using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Infrastracture.EfCore;
using DiscountManagement.Infrastracture.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscountManagementConfiguration.Bootstrapper
{
    public class DiscountManagementBootstrapper
    {
        public static void Configuration(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<ICustomerDicountRepository, CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();

            services.AddTransient<IColleagueDiscountRepository,ColleagueDiscountRepository>();
            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();


            services.AddDbContext<DiscountContext>(s => s.UseSqlServer(connectionstring));
        }
    }
}
