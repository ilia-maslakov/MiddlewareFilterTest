using CommunityToolkit.Diagnostics;
using Store.WebAPI.Middleware;

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

            return services;
        }
    }
}
