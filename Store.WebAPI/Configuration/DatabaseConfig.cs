using Microsoft.EntityFrameworkCore;
using Store.DataMigrator;

namespace Store.WebAPI.Configuration;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DataConnection"), o => { });
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}

public static class DatabaseMigrationConfig
{
    public static IApplicationBuilder UseMigrations(this IApplicationBuilder appBuilder, IConfiguration configuration, IWebHostEnvironment env)
    {
        var connection = configuration.GetConnectionString("AdminConnection");

        DbContextOptions dbOptionConf(DbContextOptionsBuilder builder)
        {
            return builder.UseNpgsql(connection).Options;
        }

        Action<StoreDbContext> dbMigrate = (context) =>
        {
            context.Database.Migrate();
        };

        Migrator.Migrate(dbOptionConf, dbMigrate);

        return appBuilder;
    }
}
