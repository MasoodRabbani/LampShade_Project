using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastracture.EfCore;
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
        private readonly ICommentApplication commentApplication;
        public ArticleQueryModel Article;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            this.articleQuery = articleQuery;
            this.articleCategoryQuery = articleCategoryQuery;
            this.commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Article = articleQuery.GetArticleQueryModelBy(id);
            LastestArticle = articleQuery.LetestArticle();
            ArticleQueries = articleCategoryQuery.GetArticleCategories();
        }
        public IActionResult OnPost(AddComment comment,string slug)
        {
            comment.Type = CommentType.Article;
            var result=commentApplication.Add(comment);
            return RedirectToPage("/Article", new { id = slug });
        }
    }
}
