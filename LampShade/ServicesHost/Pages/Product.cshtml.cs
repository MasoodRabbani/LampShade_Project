using _01_LampShadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicesHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery productQuery;

        public ProductModel(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            Product=productQuery.GetDetails(id);
        }
    }
}
