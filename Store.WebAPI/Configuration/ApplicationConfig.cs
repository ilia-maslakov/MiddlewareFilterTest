using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Store.DataContext.Context;
using Store.DataContext.Entities;
using Store.WebAPI.Filters;
using Store.WebAPI.Services;

namespace Store.WebAPI.Configuration
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            Guard.IsNotNull(configuration.GetSection("AuthServer"));
            services.Configure<AuthServerOptions>(configuration.GetSection("AuthServer"));

            // регистрация DbContext и интерфейса
            services.AddScoped<IStoreDbContext, StoreDbContext>();

            // регистрация фильтров
            services.AddScoped<ProductActionFilter>();
            services.AddScoped<ProductGetAllActionFilter>();
            services.AddScoped<ProductInfoActionFilter>();

            // сервисы
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
