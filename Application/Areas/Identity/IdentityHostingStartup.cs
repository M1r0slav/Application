using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Application.Areas.Identity.IdentityHostingStartup))]
namespace Application.Areas.Identity
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