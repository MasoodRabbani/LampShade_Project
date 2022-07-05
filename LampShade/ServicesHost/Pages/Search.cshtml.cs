using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServicesHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Value;
        public List<ProductQueryModel> Products;
        private readonly IProductQuery productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public void OnGet(string value)
        {
            Value=value;
            Products = productQuery.Search(value);
        }
    }
}
