using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> modelview { get;  set; }


        public SelectList Product;

        private readonly IProductApplication productApplication;
        private readonly ICustomerDiscountApplication customerDiscountApplication;

        public IndexModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            this.productApplication = productApplication;
            this.customerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Product = new SelectList(productApplication.GetProducts(), "Id", "Name");
            modelview = customerDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount()
            {
                Products = productApplication.GetProducts()
            };
            return Partial("./Create", command );
        }

        public IActionResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var customerdicount = customerDiscountApplication.GetDetails(id);
            customerdicount.Products = productApplication.GetProducts();
            return Partial("Edit", customerdicount);
        }

        public IActionResult OnPostEdit(EditCustomerDiscount Command)
        {
            var resuly = customerDiscountApplication.Edit(Command);
            return new JsonResult(resuly);
        }
        //public IActionResult OnGetNotIsStock(long Id)
        //{
        //    var result = productApplication.NotInStock(Id);
        //    if (result.IsSucsseded)
        //    {
        //        return RedirectToPage("./Index");
        //    }
        //    Message = result.Message;
        //    return RedirectToPage("./Index");
        //}
        //public IActionResult OnGetIsStock(long Id)
        //{
        //    var result = productApplication.InStock(Id);
        //    if (result.IsSucsseded)
        //    {
        //        return RedirectToPage("./Index");
        //    }
        //    Message = result.Message;
        //    return RedirectToPage("./Index");
        //}
    }
}
