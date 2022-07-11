using _0_Framework.Application;
using _0_Framwork.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository articleCategory;
        private readonly IFileUploader fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategory, IFileUploader fileUploader)
        {
            this.articleCategory = articleCategory;
            this.fileUploader = fileUploader;
        }

        public OprationResult Create(CreateArticleCategory command)
        {
            var oprationresult=new OprationResult();
            if (articleCategory.Exists(s=>s.Name==command.Name))
            {
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            }
            var slugy = command.Slug.Slugify();
            var picture = fileUploader.Upload(command.Picture, slugy);
            var result = new ArticleCategory(command.Name, picture,command.PictureAlt,command.PictureTitle, command.Description, command.ShowOrder,
                slugy, command.Keywords, command.MetaDescription, command.CanonicalAddress);
            articleCategory.Create(result);
            articleCategory.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditArticleCategory command)
        {
            var oprationresult = new OprationResult();
            var result = articleCategory.Get(command.Id);
            if (result == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (articleCategory.Exists(s => s.Name == command.Name))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var slugy = command.Slug.Slugify();
            var picture = fileUploader.Upload(command.Picture, slugy);
             result.Edit(command.Name, picture, command.PictureAlt, command.PictureTitle, command.Description, command.ShowOrder,
                slugy, command.Keywords, command.MetaDescription, command.CanonicalAddress);
            articleCategory.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return articleCategory.GetArticleCategory();
        }

        public EditArticleCategory GetDetails(long Id)
        {
            return articleCategory.GetDetails(Id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel model)
        {
            return articleCategory.Search(model);
        }
    }
}
