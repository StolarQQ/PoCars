using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PoCars.Infrastructure;

[assembly: HostingStartup(typeof(PoCars.Web.Areas.Identity.IdentityHostingStartup))]
namespace PoCars.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<PoCarsContext>();
            });
        }
    }
}