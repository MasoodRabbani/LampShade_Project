using _0_Framwork.Application;
using _01_LampShadeQuery.Contracts.Article;
using BlogManagement.Infracture.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery:IArticleQuery
    {
        private readonly BlogContext context;

        public ArticleQuery(BlogContext context)
        {
            this.context = context;
        }

        public ArticleQueryModel GetArticleQueryModelBy(string Slug)
        {
            var article= context.Articles.Where(s => s.PublishDate <= DateTime.Now).Include(s => s.ArticleCategory).Select(s => new ArticleQueryModel
            {
                CategoryId = s.CategoryId,
                CanonalAddress = s.CanonalAddress,
                Description = s.Description,
                Keywords = s.Keywords,
                MetaDescription = s.MetaDescription,
                CategoryName = s.ArticleCategory.Name,
                CategorySlug = s.ArticleCategory.Slug,
                Slug = s.Slug,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                PublishDate = s.PublishDate.ToFarsi(),
                ShortDescription = s.ShortDescription,
                Title = s.Title
            }).FirstOrDefault(s=>s.Slug==Slug);
            article.Keywordlist = article.Keywords.Split(",").ToList();
            return article;
        }

        public List<ArticleQueryModel> LetestArticle()
        {
            return context.Articles.Where(s=>s.PublishDate<=DateTime.Now).Include(s=>s.ArticleCategory).Select(s => new ArticleQueryModel
            {
                Slug = s.Slug,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                PublishDate = s.PublishDate.ToFarsi(),
                ShortDescription = s.ShortDescription,
                Title = s.Title
            }).ToList();
        }
    }
}
