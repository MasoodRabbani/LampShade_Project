using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServicesHost.ViewComponents
{
    public class LastestArrivals:ViewComponent
    {
        private readonly IProductQuery productQuery;

        public LastestArrivals(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var product = productQuery.GetLatestArrivals();
            return View(product);
        }
    }
}
