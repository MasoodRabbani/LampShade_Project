using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public bool IsAuthenticated()
        {
            var claims=contextAccessor.HttpContext.User.Claims.ToList();
            return claims.Count > 0;
        }

        public void Sigin(AuthViewModel account)
        {
            var claims = new List<Claim>
            {
                new Claim("Id",account.Id.ToString()),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim(ClaimTypes.Name,account.FullName),
                new Claim("UserName",account.UserName),
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
