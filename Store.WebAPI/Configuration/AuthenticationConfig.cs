using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Store.WebAPI.Configuration
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register AuthServerOptions in DI container
            services.Configure<AuthServerOptions>(configuration.GetSection("AuthServer"));

            // Add authentication services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Use AuthServerOptions to configure JWT authentication
            .AddJwtBearer(options =>
            {
                AuthServerOptions? authServerOptions = configuration.GetSection("AuthServer").Get<AuthServerOptions>();
                Guard.IsNotNull(authServerOptions, nameof(authServerOptions));

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = authServerOptions.Issuer,
                    ValidAudience = authServerOptions.Audience,
                    IssuerSigningKey = authServerOptions.GetSymmetricSecurityKey(),
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }

    public class AuthServerOptions
    {
        public string Issuer { get; set; } = "https://localhost";
        public string Audience { get; set; } = "Store.Jwt";
        public string Key { get; set; } = "mysupersecret_secretkey!123";
        public int LifetimeMinutes { get; set; } = 25; //25 min

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
