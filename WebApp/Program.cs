using System;
using System.Threading.Tasks;
using ClassLibBase;
using ClassLibModels;
using Marten;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var builder = Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
            
            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var session = services.GetRequiredService<IDocumentSession>();
                session.Store(new GenericEntity<MyData>
                {
                    Id = Guid.NewGuid(),
                    Data = new MyData
                    {
                        SomeField = "foo"
                    }
                });
                
                await session.SaveChangesAsync();

                // await martenStore.Schema.WriteMigrationFileAsync("marten-schema-patch.sql");
                // await martenStore.Schema.ApplyAllConfiguredChangesToDatabaseAsync();
            }

            return 0;
        }
    }
}