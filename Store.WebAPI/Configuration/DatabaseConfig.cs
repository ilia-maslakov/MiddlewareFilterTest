using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Store.DataContext.Context;
using Store.DataMigrator;

namespace Store.WebAPI.Configuration;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DataConnection");
        if (connectionString == null)
        {
            throw new ArgumentNullException(nameof(connectionString), "Connection string is not configured.");
        }

        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(connectionString, o => { });
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
}

public static class DatabaseMigrationConfig
{
    public static IApplicationBuilder UseMigrations(this IApplicationBuilder appBuilder, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("AdminConnection");

        Guard.IsNotNullOrWhiteSpace(connection, nameof(connection));

        DbContextOptions dbOptionConf(DbContextOptionsBuilder builder)
        {
            return builder.UseNpgsql(connection).Options;
        }

        void dbMigrate(StoreDbContext context)
        {
            context.Database.Migrate();
        }

        Migrator.Migrate(dbOptionConf, (Action<StoreDbContext>)dbMigrate);

        return appBuilder;
    }
}
