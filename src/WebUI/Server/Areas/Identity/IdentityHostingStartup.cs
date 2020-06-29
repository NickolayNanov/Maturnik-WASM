using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebUI.Server.Areas.Identity.IdentityHostingStartup))]
namespace WebUI.Server.Areas.Identity
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