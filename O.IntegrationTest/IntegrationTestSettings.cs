using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using O.Infrastructure.Data;
using OrderSystem;
using System;
using System.Net.Http;

namespace O.IntegrationTest
{
    public class IntegrationTestSettings : IDisposable
    {
        protected readonly HttpClient TestClient;
        protected readonly AppDbContext Context;
        public IntegrationTestSettings()
        {

            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        services.RemoveAll(typeof(AppDbContext));

                        services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            TestClient = appFactory.CreateClient();
            var serviceProvider = appFactory.Services;
            var serviceScope = serviceProvider.CreateScope();

            Context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            Context.Database.Migrate();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }
    }
}
