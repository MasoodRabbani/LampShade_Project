using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using _01_LampShadeQuery.Query;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infracture.EfCore;
using BlogManagement.Infracture.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogManagement.Infracture.Configuration
{
    public class BlogManagementBootstrapper
    {
        public static void Configuration(IServiceCollection services,string connectingstring)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication,ArticleCategoryApplication>();
            
            
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication,ArticleApplication>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            services.AddDbContext<BlogContext>(s => s.UseSqlServer(connectingstring));
        }
    }
}
