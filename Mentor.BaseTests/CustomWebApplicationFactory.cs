using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Mentor.BaseTests
{
    public class CustomWebApplicationFactory<Program> : WebApplicationFactory<Program> where Program : class
    {
        public CustomWebApplicationFactory()
        {
            Task.Run(async () =>
                {
                    await DB.InitAsync("UspBazaZaTestiranje",
                        MongoClientSettings.FromConnectionString(
                            "mongodb+srv://anaogrizovic211:singidingi@cluster-usp.6gdtd.mongodb.net/?retryWrites=true&w=majority&appName=Cluster-usp"));
                })
                .GetAwaiter()
                .GetResult();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Remove any existing services if necessary
                services.RemoveAll(typeof(IHostedService));
            });
        }
        
        
    }
}