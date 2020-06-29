using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Maturnik.Application.Exams.Queries.ExamsAll;
using System.Net.Http;

namespace Maturnik.WebUI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient<AuthorizationMessageHandler>(sp =>
            {
                IAccessTokenProvider provider = sp.GetRequiredService<IAccessTokenProvider>();
                NavigationManager naviManager = sp.GetRequiredService<NavigationManager>();
                AuthorizationMessageHandler handler = new AuthorizationMessageHandler(provider, naviManager);
                handler.ConfigureHandler(authorizedUrls: new[] {
                    naviManager.ToAbsoluteUri("api/").AbsoluteUri
                });

                return handler;
            });

            builder.Services.AddHttpClient("WebUI.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthorizationMessageHandler>();

            builder.Services.AddTransient(sp =>
            new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.Services.AddApiAuthorization();
            await builder.Build().RunAsync();
        }
    }
}
