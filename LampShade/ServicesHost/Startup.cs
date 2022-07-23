using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framwork.Application;
using AccountManagement.Configuration;
using BlogManagement.Infracture.Configuration;
using CommentManagement.Configuration;
using DiscountManagementConfiguration.Bootstrapper;
using InventoryManagement.Infrasturcture.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;

namespace ServicesHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();


            var connectingstring = Configuration.GetConnectionString("LampshadeDb");
            ShopManagementBootstrapper.Configure(services,connectingstring);
            DiscountManagementBootstrapper.Configuration(services,connectingstring);
            InventoryManagementBootstrapper.Configuration(services, connectingstring);
            BlogManagementBootstrapper.Configuration(services, connectingstring);
            CommentManagementBootstrapper.Configuration(services, connectingstring);
            AccountManagementBootstrapper.Configuration(services, connectingstring);
            services.AddTransient<IFileUploader,FileUploader>();
            services.AddTransient<IAuthHelper,AuthHelper>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });
            
            
            
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
