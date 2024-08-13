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

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5104/api/") });
            builder.Services.AddScoped<StudentService>();
            builder.Services.AddScoped<ParentService>();

            await builder.Build().RunAsync();
        }
    }
}
