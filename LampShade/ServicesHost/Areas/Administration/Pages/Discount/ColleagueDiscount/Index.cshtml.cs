using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.Management.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> modelview { get;  set; }


        public SelectList Product;

        private readonly IProductApplication productApplication;
        private readonly IColleagueDiscountApplication colleagueDiscountApplication;

        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            this.productApplication = productApplication;
            this.colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Product = new SelectList(productApplication.GetProducts(), "Id", "Name");
            modelview = colleagueDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount()
            {
                Products = productApplication.GetProducts()
            };
            return Partial("./Create", command );
        }

        public IActionResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var customerdicount = colleagueDiscountApplication.GetDetails(id);
            customerdicount.Products = productApplication.GetProducts();
            return Partial("Edit", customerdicount);
        }

        public IActionResult OnPostEdit(EditColleagueDiscount Command)
        {
            var resuly = colleagueDiscountApplication.Edit(Command);
            return new JsonResult(resuly);
        }
        public IActionResult OnGetRemove(long Id)
        {
            var result = colleagueDiscountApplication.Remove(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = colleagueDiscountApplication.Restore(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
