using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServicesHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel command;
        public List<ArticleCategoryQueryModel> Categorys;
        public List<ArticleQueryModel> LestestArticls;
        private readonly IArticleCategoryQuery articleCategory;
        private readonly IArticleQuery article;

        public ArticleCategoryModel(IArticleCategoryQuery articleCategory, IArticleQuery article)
        {
            this.articleCategory = articleCategory;
            this.article = article;
        }

        public void OnGet(string id)
        {
            command = articleCategory.GetArticleCategoryBy(id);
            Categorys=articleCategory.GetArticleCategories();
            LestestArticls = article.LetestArticle();

        }
    }
}
