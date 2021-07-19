using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Areas.Identity.Data;
using ShoppingCart.Data;

[assembly: HostingStartup(typeof(ShoppingCart.Areas.Identity.IdentityHostingStartup))]
namespace ShoppingCart.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShoppingCartDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShoppingCartDbContextConnection")));

                services.AddDefaultIdentity<ShoppingCartUser>(options =>
                {
                    //DEV1
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = true;
                })
                    .AddEntityFrameworkStores<ShoppingCartDbContext>();
            });
        }
    }
}