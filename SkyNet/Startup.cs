using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkyNet.Data;
using SkyNet.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var mapperConfig = new MapperConfiguration((conf) =>
                conf.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddDbContext<SkyNetDbContext>(opt => opt.UseSqlite(connection));

            services.AddIdentity<User, IdentityRole>(setup =>
                {
                    setup.Password.RequiredLength = 8;
                    setup.Password.RequireNonAlphanumeric = false;
                    setup.Password.RequireLowercase = false;
                    setup.Password.RequireUppercase = false;
                    setup.Password.RequireDigit = false;
                    setup.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<SkyNetDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            var cachePeriod = "0";

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}