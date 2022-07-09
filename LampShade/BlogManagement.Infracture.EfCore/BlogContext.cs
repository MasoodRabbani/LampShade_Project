using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infracture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogManagement.Infracture.EfCore
{
    public class BlogContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public BlogContext(DbContextOptions<BlogContext> option):base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assmbly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assmbly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
