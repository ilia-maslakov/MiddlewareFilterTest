using Store.WebAPI.Configuration;
using Store.WebAPI.Middleware;
using Serilog;
using Serilog.Events;

namespace Store.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger();

            logger.Information("Application started");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add application services
            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddDatabaseServices(builder.Configuration);
            builder.Services.AddAuthenticationServices(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<AuthorizationMiddleware>();

            app.MapControllers();

            // Apply data context migrations if they exist
            app.UseMigrations(builder.Configuration, builder.Environment);
            app.Run();

            logger.Information("Application ended");
        }
    }
}