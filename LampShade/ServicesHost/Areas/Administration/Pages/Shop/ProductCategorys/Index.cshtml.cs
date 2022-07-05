using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Shop.ProductCategorys
{
    public class IndexModel : PageModel
    {

        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> modelview { get; private set; }

        private readonly IProductCategoryApplication productcategoryapplication;

        public IndexModel(IProductCategoryApplication productcategoryapplication)
        {
            this.productcategoryapplication = productcategoryapplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            modelview = productcategoryapplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public IActionResult OnPostCreate(CreateProductCategory command)
        {
            var result = productcategoryapplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = productcategoryapplication.GetDetails(id);
            return Partial("Edit", productcategory);
        }

        public IActionResult OnPostEdit(EditProductCategory Command)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }
            var resuly = productcategoryapplication.Edit(Command);
            return new JsonResult(resuly);
        }
    }
}
