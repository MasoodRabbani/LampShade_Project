using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Reflection;

namespace ServicesHost
{
    public class SecutityPageFilter : IPageFilter
    {
        private readonly IAuthHelper authHelper;

        public SecutityPageFilter(IAuthHelper authHelper)
        {
            this.authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var permission = context.HandlerMethod.MethodInfo.GetCustomAttribute<NeedsPermissionAttribute>();
            if(permission==null)
                return;


            var accountpermission = authHelper.GetPermission();


            if (accountpermission.All(x=>x!=permission.Permission))
                context.HttpContext.Response.Redirect("/Account");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
