using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.MapperProfiles;

namespace Project
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
            services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;
                config.Position = NotyfPosition.TopRight;
            });
            services.AddControllersWithViews();
            
            services.AddAutoMapper(typeof(UserProfile));
            
            services.AddHangfire(x => x.UseSqlServerStorage("server=(localdb)\\MSSQLLocalDB;database=NewProject_DB; integrated security=true;"));
            services.AddDbContext<Context>();
            
            #region Identity

            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccesDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/Account/Index";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
            #endregion
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseNotyf();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error","?code={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseHttpsRedirection();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                DashboardTitle = "Hangfire Dashboard",
                AppPath = "/Home/HangfireDashboard"
            });
            app.UseHangfireServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "DefineEmployee",
                    pattern: "Admin/DefineEmployee/{UserId?}",
                    defaults: new { controller = "Admin", action = "DefineEmployee" });
            });
        }
    }
}