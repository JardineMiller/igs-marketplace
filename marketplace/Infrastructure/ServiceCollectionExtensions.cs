using FluentValidation.AspNetCore;
using marketplace.Data;
using marketplace.Data.Repositories;
using marketplace.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace marketplace.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Marketplace API",
                        Version = "v1"
                    });
            });

            return services;
        }

        public static IServiceCollection AddControllersWithValidation(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<ApplicationDbContext>());

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
