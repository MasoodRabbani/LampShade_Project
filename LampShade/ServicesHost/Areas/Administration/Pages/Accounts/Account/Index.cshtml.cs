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

namespace ServicesHost.Areas.Administration.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public AccountSearchModel SearchModel;
        public List<AccountViewModel> modelview { get; set; }
        public SelectList Role;
        private readonly IAccountApplication accountApplication;
        private readonly IRoleApplication roleApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            this.accountApplication = accountApplication;
            this.roleApplication = roleApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Role = new SelectList(roleApplication.Search(), "Id", "Name");
            modelview = accountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateAccount() { Roles=roleApplication.Search()};
            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateAccount command)
        {
            var result = accountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var account = accountApplication.GetDetails(id);
            account.Roles = roleApplication.Search();
            return Partial("Edit", account);
        }

        public IActionResult OnPostEdit(EditAccount Command)
        {
            var resuly = accountApplication.Edit(Command);
            return new JsonResult(resuly);
        }
        public IActionResult OnGetChangePassword(long Id)
        {
            var result = new ChangePassword { Id = Id };
            return Partial("ChangePassword", result);
        }
        public IActionResult OnPostChangePassword(ChangePassword command)
        {
            var result=accountApplication.ChangePassword(command);
            return new JsonResult(result);
        }
    }
}
