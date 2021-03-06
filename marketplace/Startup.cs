using System.Reflection;
using marketplace.Data.Seeds;
using marketplace.Infrastructure;
using marketplace.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace marketplace
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithValidation()
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddDatabase(Configuration)
                .AddApplicationServices()
                .AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseCustomExceptionHandler()
                .UseSwaggerUI()
                .UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); })
                .ApplyMigrations();

            seeder.Seed();
        }
    }
}
