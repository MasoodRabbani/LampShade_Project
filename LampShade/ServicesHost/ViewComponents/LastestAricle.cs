using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class LastestArticleViewComponent : ViewComponent
    {
        private readonly IArticleQuery articleQuery;

        public LastestArticleViewComponent(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = articleQuery.LetestArticle();
            return View(result);
        }
    }
}
