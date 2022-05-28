using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManegement.Infrastracture.EFCore.Mapping
{
    public class MappingProductCategory : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(255).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.Picture).HasMaxLength(1000);
            builder.Property(s => s.PictureAlt).HasMaxLength(250);
            builder.Property(s => s.PictureTitle).HasMaxLength(500);
            builder.Property(s => s.Keywords).HasMaxLength(80).IsRequired();
            builder.Property(s => s.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(s => s.Slug).HasMaxLength(300).IsRequired();
        }
    }
}
