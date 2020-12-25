using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(LuxuryEstateProject.Web.Areas.Identity.IdentityHostingStartup))]
namespace LuxuryEstateProject.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}