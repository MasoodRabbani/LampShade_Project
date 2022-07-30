using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framwork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopmanagement.Configoration.Permission;
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
        [NeedsPermission(ShopPermission.ListCategoryProduct)]
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            modelview = productcategoryapplication.Search(searchModel);
        }
        [NeedsPermission(ShopPermission.CreateCategoryProduct)]

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        [NeedsPermission(ShopPermission.CreateCategoryProduct)]

        public IActionResult OnPostCreate(CreateProductCategory command)
        {
            var result = productcategoryapplication.Create(command);
            return new JsonResult(result);

        }
        [NeedsPermission(ShopPermission.EditCategoryProduct)]

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = productcategoryapplication.GetDetails(id);
            return Partial("Edit", productcategory);
        }
        [NeedsPermission(ShopPermission.EditCategoryProduct)]

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
