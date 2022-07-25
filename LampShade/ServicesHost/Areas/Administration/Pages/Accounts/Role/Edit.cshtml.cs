using _0_Framwork.Infrastructure;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ServicesHost.Areas.Administration.Pages.Accounts.Role
{
    public class EditModel : PageModel
    {
        public List<SelectListItem> Permissions=new List<SelectListItem>();
        public EditRole command { get; set; }
        private readonly IRoleApplication roleApplication;
        private readonly IEnumerable<IPermissionExposer> exposers;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            this.roleApplication = roleApplication;
            this.exposers = exposers;
        }

        public void OnGet(long id)
        {
            command = roleApplication.GetDetails(id);
            var permission = new List<PermissionDto>();
            foreach (var e in exposers)
            {
                var expos = e.Exposer();
                foreach (var (Key,value) in expos)
                {
                    permission.AddRange(value);
                    var group = new SelectListGroup()
                    {
                        Name=Key
                    };
                    foreach(var permissiond in value)
                    {
                        var ithem = new SelectListItem(permissiond.Name, permissiond.Code.ToString())
                        {
                            Group=group
                        };
                        if (command.MappedPermissions.Any(s => s.Code == permissiond.Code))
                            ithem.Selected = true;

                        Permissions.Add(ithem);
                    }
                }
            }
        }

        public IActionResult OnPost(EditRole Command)
        {
            var result= roleApplication.Edit(Command);
            return new RedirectToPageResult("Index",result);
        }
    }
}
