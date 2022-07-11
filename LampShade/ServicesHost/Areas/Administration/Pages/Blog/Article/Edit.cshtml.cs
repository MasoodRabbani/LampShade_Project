using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServicesHost.Areas.Administration.Pages.Blog.Article
{
    public class EditModel : PageModel
    {
        public EditArticle command;
        public SelectList Category;

        private readonly IArticleApplication articleApplication;
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleApplication = articleApplication;
            this.articleCategoryApplication = articleCategoryApplication;
        }

        
        public void OnGet(long Id)
        {
            Category = new SelectList(articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            command=articleApplication.GetDetails(Id);
        }
        public IActionResult OnPost(EditArticle command)
        {
            var result = articleApplication.Edit(command);
            return RedirectToPage("./Index", result);
        }
    }
}
