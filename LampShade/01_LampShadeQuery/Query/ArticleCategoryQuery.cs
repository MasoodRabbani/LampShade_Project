using _0_Framwork.Application;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infracture.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ArticleCategoryQuery: IArticleCategoryQuery
    {
        private readonly BlogContext context;

        public ArticleCategoryQuery(BlogContext context)
        {
            this.context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return context.ArticleCategories.Include(s=>s.Articles).Select(s => new ArticleCategoryQueryModel
            {
                CountArticle=s.Articles.Count,
                Id=s.Id,
                Name = s.Name,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Slug = s.Slug,
            }).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategoryBy(string Slug)
        {
            var category= context.ArticleCategories.Include(s=>s.Articles).Select(s => new ArticleCategoryQueryModel
            {
                Id = s.Id,
                Name = s.Name,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Slug = s.Slug,
                MetaDescription = s.MetaDescription,
                Keywords = s.Keywords,
                Description = s.Description,
                CanonicalAddress = s.CanonicalAddress,
                CountArticle=s.Articles.Count,
                Articls=MapArticls(s.Articles),
                
            }).FirstOrDefault(s => s.Slug == Slug);

            category.KeywordList = category.Keywords.Split("،").ToList();

            return category;    
        }

        private static List<ArticleQueryModel> MapArticls(List<Article> articles)
        {
            return articles.Select(s=>new ArticleQueryModel
            {
                Slug = s.Slug,
                ShortDescription = s.ShortDescription,
                Title = s.Title,
                Picture=s.Picture,
                PictureAlt=s.PictureAlt,
                PictureTitle=s.PictureTitle,
                PublishDate=s.PublishDate.ToFarsi()
            }).ToList();
        }
    }
}
