using _0_Framwork.Application;
using _01_LampShadeQuery.Contracts.Article;
using BlogManagement.Infracture.EfCore;
using CommentManagement.Infrastracture.EfCore;
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
        private readonly CommentContext commentcontext;

        public ArticleQuery(BlogContext context, CommentContext commentcontext)
        {
            this.context = context;
            this.commentcontext = commentcontext;
        }

        public ArticleQueryModel GetArticleQueryModelBy(string Slug)
        {
            var article= context.Articles
                .Where(s => s.PublishDate <= DateTime.Now)
                .Include(s => s.ArticleCategory)
                .Select(s => new ArticleQueryModel
            {
                Id = s.Id,
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
            var comments = commentcontext.Comments.Where(s => s.Type == CommentType.Article)
                .Where(s => !s.IsCanceled && s.IsConfirmed)
                .Where(s => s.OwnerRecordId == article.Id)
                .Select(s => new Contracts.Comment.CommentQueryModel
                {
                    Id = s.Id,
                    Message = s.Message,
                    Name = s.Name,
                    ParentId = s.ParentId,
                    CreationDate=s.CreationDate.ToFarsi()
                }).OrderByDescending(s => s.Id).ToList();

            foreach (var item in comments)
            {
                if (item.ParentId > 0)
                    item.ParentName = comments.FirstOrDefault(s => item.ParentId == s.Id)?.Name;
            }
            article.Comments = comments;


            if(!string.IsNullOrWhiteSpace(article.Keywords))
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
