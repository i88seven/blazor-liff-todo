using LineDC.Liff;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TodoBot.Client.Services;

namespace TodoBot.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            var appSettings = builder.Configuration.Get<AppSettings>();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });
            builder.Services.AddSingleton<ILiffClient>(serviceProvider =>
            {
                return new LiffClient(appSettings.LiffId);
            });

            builder.Services.AddSingleton<ITodoClient>(serviceProvider =>
            {
                var httpClient = serviceProvider.GetRequiredService<HttpClient>();
                return new TodoClient(httpClient, appSettings?.FunctionUrl);
            });
            await builder.Build().RunAsync();
        }
    }
}
