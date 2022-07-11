using _0_Framwork.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OprationResult Create(CreateArticleCategory command);
        OprationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(long Id);
        List<ArticleCategoryViewModel> GetArticleCategories();
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel model);
    }
}
