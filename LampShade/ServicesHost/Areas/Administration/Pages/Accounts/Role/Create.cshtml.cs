using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ServicesHost.Areas.Administration.Pages.Accounts.Role
{
    public class CreateModel : PageModel
    {
        public CreateRole command { get; set; }
        private readonly IRoleApplication roleApplication;

        public CreateModel(IRoleApplication roleApplication)
        {
            this.roleApplication = roleApplication;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(CreateRole command)
        {
            var result = roleApplication.Create(command);
            return new RedirectToPageResult("Index",result);
        }
    }
}
