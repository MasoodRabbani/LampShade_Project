using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infracture.EfCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable(nameof(ArticleCategory));
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(500).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(2000);
            builder.Property(s => s.Picture).HasMaxLength(500);
            builder.Property(s => s.PictureAlt).HasMaxLength(500);
            builder.Property(s => s.PictureTitle).HasMaxLength(500);
            builder.Property(s => s.Slug).HasMaxLength(600);
            builder.Property(s => s.Keywords).HasMaxLength(100);
            builder.Property(s => s.MetaDescription).HasMaxLength(150);
            builder.Property(s => s.CanonicalAddress).HasMaxLength(1000);
            builder.Property(s => s.ShowOrder).HasMaxLength(100);

            builder.HasMany(s => s.Articles)
                .WithOne(s => s.ArticleCategory)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}
