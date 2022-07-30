using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public class Roles
    {
        public const string Administration = "1";
        public const string UserSystem = "2";
        public const string ContentAppend = "3";
        public const string Admin = "4";
        public const string Collague = "10011";
        public static string GetRoleBy(string Id)
        {
            switch (Id)
            {
                case Administration: return nameof(Administration);
                case UserSystem: return nameof(UserSystem);
                case ContentAppend: return nameof(Administration);
                case Admin: return nameof(Admin);
                case Collague: return nameof(Collague);
                default:
                    return "NotFound";
            }
        }
    }
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public string CurrentAccountRoleId()
        {
            return IsAuthenticated() ? contextAccessor.HttpContext.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Role)?.Value : "";
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result=new AuthViewModel();
            if(!IsAuthenticated())
                return result;
            var claims = contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = long.Parse(claims.FirstOrDefault(s => s.Type == "Id").Value);
            result.UserName = claims.FirstOrDefault(s => s.Type == "UserName").Value;
            result.RoleId =long.Parse(claims.FirstOrDefault(s => s.Type == ClaimTypes.Role).Value);
            result.FullName =claims.FirstOrDefault(s => s.Type == ClaimTypes.Name).Value;
            result.Role = Roles.GetRoleBy(result.RoleId.ToString());

            return result;
        }

        public List<int> GetPermission()
        {
            if(!IsAuthenticated())
                return new List<int>();
            var test = contextAccessor.HttpContext.User.Claims.ToList();
            var permission
                 = contextAccessor.HttpContext.User.Claims.FirstOrDefault(s => s.Type == "permissions")?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permission);
        }

        public bool IsAuthenticated()
        {
            return contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims=contextAccessor.HttpContext.User.Claims.ToList();
            //return claims.Count > 0;
        }

        public void Sigin(AuthViewModel account)
        {
            var permission=JsonConvert.SerializeObject(account.Permission);
            var claims = new List<Claim>
            {
                new Claim("Id",account.Id.ToString()),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim(ClaimTypes.Name,account.FullName),
                new Claim("UserName",account.UserName),
                new Claim("permissions",permission)
            };
            var claimidentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var authPeropertis = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };
            contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                , new ClaimsPrincipal(claimidentity)
                , authPeropertis);
        }

        public void Sigout()
        {
            contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
