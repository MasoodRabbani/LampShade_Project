using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> modelview { get; set; }


        public SelectList product;

        private readonly IProductApplication productApplication;
        private readonly IProductPictureApplication productPictureApplication;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            this.productApplication = productApplication;
            this.productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            product = new SelectList(productApplication.GetProducts(), "Id", "Name");
            modelview = productPictureApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPiccture()
            {
                Products= productApplication.GetProducts(),
            };
            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateProductPiccture command)
        {
            var result = productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = productPictureApplication.GetDetails(id);
            productcategory.Products = productApplication.GetProducts();
            return Partial("Edit", productcategory);
        }

        public IActionResult OnPostEdit(EditProductPicture Command)
        {
            var resuly = productPictureApplication.Edit(Command);
            return new JsonResult(resuly);
        }
        public IActionResult OnGetRemove(long Id)
        {
            var result = productPictureApplication.Remove(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = productPictureApplication.Restore(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
