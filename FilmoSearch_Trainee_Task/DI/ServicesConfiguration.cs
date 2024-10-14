using API.Extensions;
using FilmoSearch.BusinessLogicLayer.DI;
using FilmoSearch_Trainee_Task.Authorization;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
using System.Security.Claims;

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
            services.AddAuth0Authentication(configuration);
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
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimTypes.NameIdentifier
            };
        });

            services.AddAuthorizationBuilder()
               .AddPolicy("change:list", policy => policy.Requirements.Add(new
                HasScopeRequirement("change:list", configuration["Auth0:Domain"])));
                

        }
    }
}
