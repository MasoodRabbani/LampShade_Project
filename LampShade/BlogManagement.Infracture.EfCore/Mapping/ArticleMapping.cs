using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infracture.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable(nameof(Article));
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).HasMaxLength(500).IsRequired();
            builder.Property(s => s.ShortDescription).HasMaxLength(1000);
            builder.Property(s => s.Picture).HasMaxLength(500);
            builder.Property(s => s.PictureAlt).HasMaxLength(500);
            builder.Property(s => s.PictureTitle).HasMaxLength(500);
            builder.Property(s => s.Slug).HasMaxLength(600);
            builder.Property(s => s.Keywords).HasMaxLength(150);
            builder.Property(s => s.MrtaDescription).HasMaxLength(150);
            builder.Property(s => s.CanonalAddress).HasMaxLength(1000);
            builder.Property(s => s.PublishDate);
            builder.Property(s => s.Description);


            builder.HasOne(s => s.ArticleCategory)
                .WithMany(s => s.Articles)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}
