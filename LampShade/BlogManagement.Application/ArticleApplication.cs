using _0_Framework.Application;
using _0_Framwork.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository articleRepository;
        private readonly IFileUploader fileUploader;
        private readonly IArticleCategoryRepository articleCategoryRepository;

        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleRepository = articleRepository;
            this.fileUploader = fileUploader;
            this.articleCategoryRepository = articleCategoryRepository;
        }

        public OprationResult Create(CreateArticle command)
        {
            var oprationresult=new OprationResult();
            if (articleRepository.Exists(s => s.Title == command.Title && s.CategoryId == command.CategoryId))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var slugy = command.Slug.Slugify();
            var categoryslug = articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path =$"{categoryslug}/{slugy}";
            var picture = fileUploader.Upload(command.Picture, path);
            var result = new Article(command.CategoryId, command.Title, command.ShortDescription,
                command.Description, picture, command.PictureAlt, command.PictureTitle,slugy,
                command.PublishDate.ToGeorgianDateTime(), command.Keywords, command.MetaDescription,
                command.CanonalAddress);
            articleRepository.Create(result);
            articleRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }


        public OprationResult Edit(EditArticle command)
        {
            var oprationresult = new OprationResult();
            var result = articleRepository.GetCategoryBy(command.Id);
            if(result == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (articleRepository.Exists(s => s.Title == command.Title &&s.Id!=command.Id&& s.CategoryId == command.CategoryId))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var slugy = command.Slug.Slugify();
            var path = $"{result.ArticleCategory.Slug}/{slugy}";
            var picture = fileUploader.Upload(command.Picture, path);
            result.Edit(command.CategoryId, command.Title, command.ShortDescription,
                command.Description, picture, command.PictureAlt, command.PictureTitle, slugy,
                command.PublishDate.ToGeorgianDateTime(), command.Keywords, command.MetaDescription,
                command.CanonalAddress);
            articleRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditArticle GetDetails(long Id)
        {
            return articleRepository.GetDetails(Id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel model)
        {
            return articleRepository.Search(model);
        }
    }
}
