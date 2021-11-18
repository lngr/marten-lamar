using System;
using ClassLibBase;
using ClassLibModels;
using Marten;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Postgresql;

namespace WebApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void Configure()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMarten(options =>
            {
                options.Connection(Configuration.GetConnectionString("Default"));
                options.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
                
                options.Schema.For<GenericEntity<MyData>>();
            });
        }
    }
}