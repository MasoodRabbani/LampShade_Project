using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Infrastracture.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Name).HasMaxLength(255).IsRequired();
            builder.Property(s => s.Slug).IsRequired();
            builder.Property(s => s.Code).HasMaxLength(15).IsRequired();
            builder.Property(s => s.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(s => s.Picture).HasMaxLength(1000);
            builder.Property(s => s.PictureAlt).HasMaxLength(255);
            builder.Property(s => s.PictureTitle).HasMaxLength(500);
            builder.Property(s => s.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(s => s.MetaDescription).HasMaxLength(150).IsRequired();




            builder.HasOne(s => s.ProductCategory)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.CategoryId);


            builder.HasMany(s=>s.ProductPictures)
                .WithOne(s=>s.Product)
                .HasForeignKey(s => s.ProductId);
        }
    }
}
