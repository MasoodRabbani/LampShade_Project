using Discount.Management.Domain.ColleagueDiscountAgg;
using Discount.Management.Domain.CoustomDiscountAgg;
using DiscountManagement.Infrastracture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace DiscountManagement.Infrastracture.EfCore
{
    public class DiscountContext : DbContext
    {
        public DiscountContext( DbContextOptions<DiscountContext> options) : base(options)
        {
        }
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assmbly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assmbly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
