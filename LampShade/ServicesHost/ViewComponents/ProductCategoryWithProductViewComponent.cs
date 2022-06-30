using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class ProductCategoryWithProductViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery productCategoryQuery;

        public ProductCategoryWithProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var category = productCategoryQuery.GetProductCategoriesWithProducts();
            return View(category);
        }
    }
}
