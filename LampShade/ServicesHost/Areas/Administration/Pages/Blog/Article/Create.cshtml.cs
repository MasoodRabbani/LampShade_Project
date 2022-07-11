using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServicesHost.Areas.Administration.Pages.Blog.Article
{
    public class CreateModel : PageModel
    {
        public SelectList Categories;
        public CreateArticle command;
        private readonly IArticleCategoryApplication articleCategoryApplication;
        private readonly IArticleApplication articleApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
            this.articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Categories = new SelectList(articleCategoryApplication.GetArticleCategories(), "Id", "Name");
        }
        public IActionResult OnPost(CreateArticle command)
        {
            var result = articleApplication.Create(command);
            return RedirectToPage("./Index",result);
        }
    }
}
