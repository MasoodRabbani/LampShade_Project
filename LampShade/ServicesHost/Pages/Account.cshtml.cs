using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicesHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication accountApplication;
        public AccountModel(IAccountApplication accountApplication)
        {
            this.accountApplication = accountApplication;
        }
        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPostLogin(Login login)
        {
            var result = accountApplication.Login(login);
            if (result.IsSucsseded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("/Account");
        }
        public IActionResult OnGetLogout()
        {
            accountApplication.Logout();
            return RedirectToPage("./Index");
        }
    }
}
