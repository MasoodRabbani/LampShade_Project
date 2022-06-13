using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagement.Infrastructure.EfCore
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }


        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {

        }
    }
}
