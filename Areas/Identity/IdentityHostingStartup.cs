using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeWebsite.Data;

[assembly: HostingStartup(typeof(OfficeWebsite.Areas.Identity.IdentityHostingStartup))]
namespace OfficeWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OfficeWebsiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OfficeWebsiteContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<OfficeWebsiteContext>();
            });
        }
    }
}