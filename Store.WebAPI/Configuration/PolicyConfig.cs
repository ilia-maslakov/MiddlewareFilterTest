using Microsoft.AspNetCore.Authorization;

namespace Store.WebAPI.Configuration;

public static class PolicyConfig
{
    public static IServiceCollection AddPolicyServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Access police service
        //services.AddScoped<IAccessPolicyService, AccessPolicyService>();

        // Register authorization policies
        services.AddAuthorization(options =>
        {
            //options.AddPolicy(AppPolicies.ProjectId, p => p.Requirements.Add(new ProjectIdPolicyRequirement()));
            //options.AddPolicy(AppPolicies.ProjectInput, p => p.Requirements.Add(new ProjectInputPolicyRequirement()));

        });

        // Register requirement handler service
        //services.AddScoped<IAuthorizationHandler, ProjectIdPolicyHandler>();
        //services.AddScoped<IAuthorizationHandler, ProjectInputPolicyHandler>();

        return services;
    }
}
