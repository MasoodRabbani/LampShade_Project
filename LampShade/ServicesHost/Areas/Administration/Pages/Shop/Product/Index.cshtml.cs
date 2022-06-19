using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public ProductSearchModel SearchModel;
        public List<ProductViewModel> modelview { get; private set; }


        public SelectList ProductCategorys;

        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            this.ProductCategorys = new SelectList(productCategoryApplication.GetProductCategories(),"Id","Name");
            modelview = productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct()
            {
                Categoris=productCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateProduct command)
        {
            var result = productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = productApplication.GetDetails(id);
            productcategory.Categoris=productCategoryApplication.GetProductCategories();
            return Partial("Edit", productcategory);
        }

        public IActionResult OnPostEdit(EditProduct Command)
        {
            var resuly = productApplication.Edit(Command);
            return new JsonResult(resuly);
        }
    }
}
