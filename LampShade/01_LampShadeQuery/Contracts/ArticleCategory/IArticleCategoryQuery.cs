using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryModel GetArticleCategoryBy(string Slug);
        List<ArticleCategoryQueryModel> GetArticleCategories();
    }
}
