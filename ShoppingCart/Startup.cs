using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AuthSystem.Models;
//using AuthSystem.Repository;
//using AuthSystem.Repository.IRepository;

namespace ShoppingCart
{
    public class Startup
    {

        //private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            //_configuration = configuration;
            Configuration = configuration;

            //string var1 = _configuration.GetConnectionString("DefaultConnection");
            string var1 = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ShoppingCartDbContextConnection")));

            //string var5 = _configuration.GetConnectionString("DefaultConnection");
            string var5 = Configuration.GetConnectionString("ShoppingCartDbContextConnection");
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            //DEV1
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //DEV1
                endpoints.MapRazorPages();
            });
        }
    }
}
