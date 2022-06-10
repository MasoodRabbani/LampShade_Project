using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServicesHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery productCategory;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategory)
        {
            this.productCategory = productCategory;
        }

        public IViewComponentResult Invoke()
        {
            var productcategory = productCategory.GetProductCategories();
            return View(productcategory);
        }
    }
}
