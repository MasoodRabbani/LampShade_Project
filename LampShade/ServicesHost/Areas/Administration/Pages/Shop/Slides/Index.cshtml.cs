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
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public List<SlideViewModel> modelview { get; private set; }

        private readonly ISlideApplication slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            this.slideApplication = slideApplication;
        }

        public void OnGet()
        {
            modelview = slideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateSlide());
        }

        public IActionResult OnPostCreate(CreateSlide command)
        {
            var result = slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = slideApplication.GetDetails(id);
            return Partial("Edit", slide);
        }

        public IActionResult OnPostEdit(EditSlide Command)
        {
            var resuly = slideApplication.Edit(Command);
            return new JsonResult(resuly);
        }
        public IActionResult OnGetRemove(long Id)
        {
            var result = slideApplication.Remove(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = slideApplication.Restore(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
