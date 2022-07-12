using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServicesHost.Pages
{
    public class ArticleModel : PageModel
    {
        public List<ArticleQueryModel> LastestArticle;
        public List<ArticleCategoryQueryModel> ArticleQueries;
        private readonly IArticleQuery articleQuery;
        private readonly IArticleCategoryQuery articleCategoryQuery;
        public ArticleQueryModel Article;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            this.articleQuery = articleQuery;
            this.articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            Article = articleQuery.GetArticleQueryModelBy(id);
            LastestArticle = articleQuery.LetestArticle();
            ArticleQueries = articleCategoryQuery.GetArticleCategories();
        }
    }
}
