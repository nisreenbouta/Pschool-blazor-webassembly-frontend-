using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using PschoolClient.Services;
using PschoolFrontend;

namespace PschoolClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Set the base address for the HTTP client
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5104/api") });

            // Register services
            builder.Services.AddScoped<ParentService>();
            builder.Services.AddScoped<StudentService>();

            await builder.Build().RunAsync();
        }
    }
}
