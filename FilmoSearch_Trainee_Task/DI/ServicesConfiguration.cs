using FilmoSearch.BusinessLogicLayer.DI;
using FluentValidation;
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
        }
    }
}
