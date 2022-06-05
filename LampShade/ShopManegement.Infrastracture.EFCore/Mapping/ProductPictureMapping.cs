using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Infrastracture.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictue");
            builder.HasKey(p => p.Id);
            builder.Property(s=>s.Picture).HasMaxLength(10000).IsRequired();
            builder.Property(s=>s.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(s=>s.PictureAlt).HasMaxLength(500).IsRequired();

            builder.HasOne(p => p.Product).WithMany(s=>s.ProductPictures).HasForeignKey(p => p.ProductId);
        }
    }
}
