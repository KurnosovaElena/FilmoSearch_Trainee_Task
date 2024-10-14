using API.Extensions;
using FilmoSearch.BusinessLogicLayer.DI;
using FilmoSearch_Trainee_Task.Authorization;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

namespace FilmoSearch_Trainee_Task.DI
{
    public static class ServicesConfiguration
    {
        public static void AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusinessLogicDependencies(configuration);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.ConfigureSwagger();
        }

        private static void AddAuth0Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(
        options =>
        {
            options.Authority = $"https://{configuration["Auth0:Domain"]}/";
            options.Audience = configuration["Auth0:Audience"];
        });

            services.AddAuthorizationBuilder()
                .AddPolicy("change:catalogue", policy =>
                    policy.Requirements.Add(
                        new HasScopeRequirement("change:catalogue", configuration["Auth0:Domain"])
                        ));

        }
    }
}
