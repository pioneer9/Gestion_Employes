using System;
using Gestion_Employes.Areas.Identity.Data;
using Gestion_Employes.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Gestion_Employes.Areas.Identity.IdentityHostingStartup))]
namespace Gestion_Employes.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Gestion_EmployesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BD")));

                services.AddDefaultIdentity<Gestion_EmployesUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Gestion_EmployesContext>();
            });
        }
    }
}