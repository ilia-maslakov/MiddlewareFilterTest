using Microsoft.AspNetCore.Authorization;
using Serilog;
using Store.WebAPI.Configuration;

namespace Store.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // �������� ����� ������ AddLoggerServices ��� ��������� Serilog
            services.AddLoggerServices(Configuration);

            services.AddLoggerServices(Configuration);

            services.AddApplicationServices(Configuration);

            services.AddDatabaseServices(Configuration);
            services.AddAuthenticationServices(Configuration);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���������� Serilog middleware ��� ����������� ��������
            app.UseSerilogRequestLogging();
            app.UseRouting();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<AuthorizationMiddleware>();


            // Apply data context migrations if they exist
            app.UseMigrations(Configuration, env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}