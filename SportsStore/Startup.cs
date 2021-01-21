using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//EFCore config.
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
// Identity.
using Microsoft.AspNetCore.Identity;

namespace SportsStore
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //EFCore config.
            services.AddDbContext<StoreDbContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:SportsStoreConnection"]);
            });

            // Creates a service where each HTTP request gets its own repository object (EF is used).
            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddRazorPages();

            // Sessions to store User's Cart data.
            services.AddDistributedMemoryCache();
            services.AddSession();

            /* Service for the Cart class.
             * The AddScoped method specifies that the same object should be used to satisfy related requests for 
            Cart instances. How requests are related can be configured, but by default, it means that any Cart 
            required by components handling the same HTTP request will receive the same object.
            The lambda expression receives the collection of services that have been registered and passes the collection to the GetCart method 
            of the SessionCart class. The result is that requests for the Cart service will be handled by 
            creating SessionCart objects, which will serialize themselves as session data when they are modified.
            */
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            // This service is required to access the SessionCart class.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddServerSideBlazor();

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer( 
                Configuration["ConnectionStrings:IdentityConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Middleware components.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("catpage", "{category}/Page{productPage:int}",
                new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("pagination", "Products/Page{productPage}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
