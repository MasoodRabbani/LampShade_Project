using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery productCategoryQuery;

        public FooterViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
