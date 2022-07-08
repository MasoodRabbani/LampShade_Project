using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Infrastracture.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(nameof(Comment));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(500);
            builder.Property(c => c.Email).HasMaxLength(500);
            builder.Property(c => c.Message).HasMaxLength(1000);

            builder.HasOne(s => s.Product).WithMany(s => s.Comments).HasForeignKey(s => s.ProductId);
        }
    }
}
