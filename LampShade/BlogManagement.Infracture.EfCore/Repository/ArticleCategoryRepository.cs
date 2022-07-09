using _0_Framwork.Application;
using _0_Framwork.Domain;
using _0_Framwork.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infracture.EfCore.Repository
{
    public class ArticleCategoryRepository:RepositoryBase<long,ArticleCategory>,IArticleCategoryRepository
    {
        private readonly BlogContext context;

        public ArticleCategoryRepository(BlogContext context):base(context)
        {
            this.context = context;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return context.ArticleCategories.Select(s => new EditArticleCategory
            {
                Id = s.Id,
                CanonicalAddress = s.CanonicalAddress,
                Description = s.Description,
                Keywords = s.Keywords,
                MetaDescription = s.MetaDescription,
                Name = s.Name,
                ShowOrder = s.ShowOrder,
                Slug = s.Slug,
                PictureTitle = s.PictureTitle,
                PictureAlt = s.PictureAlt,
            }).FirstOrDefault(s => s.Id == id);
        }

        public string GetSlugBy(long id)
        {
            return context.ArticleCategories.FirstOrDefault(s=>s.Id==id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel model)
        {
            var query = context.ArticleCategories.Select(s => new ArticleCategoryViewModel
            {
                CreationDate = s.CreationDate.ToFarsi(),
                Id = s.Id,
                Description = s.Description,
                Name = s.Name,
                ShowOrder = s.ShowOrder,
                Picture = s.Picture
            });
            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(s => s.Name.Contains(model.Name));
            return query.OrderByDescending(s=>s.ShowOrder).ToList();
        }
    }
}
