using Discount.Management.Domain.CoustomDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastracture.EfCore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable(nameof(CustomerDiscount));
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Reason).HasMaxLength(500);
        }
    }
}
