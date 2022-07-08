using _01_LampShadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Comment;

namespace ServicesHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery productQuery;
        private readonly ICommentApplication commentapplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentapplication)
        {
            this.productQuery = productQuery;
            this.commentapplication = commentapplication;
        }

        public void OnGet(string id)
        {
            Product=productQuery.GetDetails(id);
        }
        public IActionResult OnPost(AddComment comment,string Slug)
        {
            var result = commentapplication.Add(comment);
            return RedirectToPage("/Product", new { Id = Slug });
        }
    }
}
