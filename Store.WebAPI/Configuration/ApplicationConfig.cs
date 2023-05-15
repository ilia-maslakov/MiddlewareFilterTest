using CommunityToolkit.Diagnostics;

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

            return services;
        }
    }
}
