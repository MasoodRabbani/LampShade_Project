using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public List<RoleViewModel> modelview { get; set; }
        private readonly IRoleApplication roleApplication;

        public IndexModel(IRoleApplication roleApplication)
        {
            this.roleApplication = roleApplication;
        }

        public void OnGet()
        {
            modelview = roleApplication.Search();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateRole();
            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateRole command)
        {
            var result = roleApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var account = roleApplication.GetDetails(id);
            return Partial("Edit", account);
        }

        public IActionResult OnPostEdit(EditRole Command)
        {
            var resuly = roleApplication.Edit(Command);
            return new JsonResult(resuly);
        }
    }
}
