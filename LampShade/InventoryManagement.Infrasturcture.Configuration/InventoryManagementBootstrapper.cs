using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Infrasturcture.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configuration(IServiceCollection services,string connectingstring)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();


            services.AddDbContext<InventoryContext>(s => s.UseSqlServer(connectingstring));
        }
    }
}
