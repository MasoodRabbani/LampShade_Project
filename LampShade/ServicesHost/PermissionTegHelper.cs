using _0_Framwork.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace ServicesHost
{
    [HtmlTargetElement(Attributes ="Permission")]
    public class PermissionTegHelper:TagHelper
    {
        private readonly IAuthHelper authHelper;

        public PermissionTegHelper(IAuthHelper authHelper)
        {
            this.authHelper = authHelper;
        }
        public int Permission { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }
            var permission = authHelper.GetPermission();
            if (permission.All(s=>s!=Permission))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}
