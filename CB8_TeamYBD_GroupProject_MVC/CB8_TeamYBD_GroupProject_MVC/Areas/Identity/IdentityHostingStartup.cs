using System;
using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
using CB8_TeamYBD_GroupProject_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CB8_TeamYBD_GroupProject_MVC.Areas.Identity.IdentityHostingStartup))]
namespace CB8_TeamYBD_GroupProject_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CB8_TeamYBD_GroupProject_MVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CB8_TeamYBD_GroupProject_MVCContextConnection")));

                services.AddDefaultIdentity<CB8_TeamYBD_GroupProject_MVCUser>()
                    .AddEntityFrameworkStores<CB8_TeamYBD_GroupProject_MVCContext>();
            });
        }
    }
}