using _01_LampShadeQuery;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery productCategoryQuery;
        private readonly IArticleCategoryQuery articleCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
            this.articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                ArticleCategoryQueries = articleCategoryQuery.GetArticleCategories(),
                ProductCategoryQueries = productCategoryQuery.GetProductCategories(),
            };
            return View(result);
        }
    }
}
