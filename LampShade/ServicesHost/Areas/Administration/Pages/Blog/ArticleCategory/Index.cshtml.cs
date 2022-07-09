using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {

        public ArticleCategorySearchModel SearchModel;
        public List<ArticleCategoryViewModel> modelview { get; set; }

        private readonly IArticleCategoryApplication articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            modelview = articleCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }

        public IActionResult OnPostCreate(CreateArticleCategory command)
        {
            var result = articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = articleCategoryApplication.GetDetails(id);
            return Partial("Edit", productcategory);
        }

        public IActionResult OnPostEdit(EditArticleCategory Command)
        {
            var resuly = articleCategoryApplication.Edit(Command);
            return new JsonResult(resuly);
        }
    }
}
