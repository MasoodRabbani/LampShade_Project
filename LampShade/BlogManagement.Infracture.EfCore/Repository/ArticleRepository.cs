using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infracture.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext context;

        public ArticleRepository(BlogContext context):base(context)
        {
            this.context = context;
        }

        public Article GetCategoryBy(long Id)
        {
            return context.Articles.Include(s => s.ArticleCategory).FirstOrDefault(s => s.Id == Id);
        }

        public EditArticle GetDetails(long id)
        {
            return context.Articles.Select(s => new EditArticle
            {
                Id = s.Id,
                Title = s.Title,
                CanonalAddress = s.CanonalAddress,
                CategoryId = s.CategoryId,
                Description = s.Description,
                Keywords = s.Keywords,
                MetaDescription = s.MetaDescription,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                //Picture = s.Picture,
                PublishDate = s.PublishDate.ToFarsi(),
                ShortDescription = s.ShortDescription,
                Slug = s.Slug
            }).FirstOrDefault(s => s.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel model)
        {
            var query = context.Articles.Include(s=>s.ArticleCategory).Select(s => new ArticleViewModel
            {
                Id = s.Id,
                CategoryId=s.CategoryId,
                Category = s.ArticleCategory.Name,
                Picture = s.Picture,
                ShortDescription = s.ShortDescription,
                Title = s.Title,
                PublishDate = s.PublishDate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(model.Title))
                query = query.Where(s => s.Title.Contains(model.Title));
            if (model.CategoryId > 0)
                query = query.Where(s => s.CategoryId == model.CategoryId);
            return query.OrderByDescending(s => s.Id).ToList();
        }
    }
}
