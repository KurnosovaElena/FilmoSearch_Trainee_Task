using FilmoSearch.BusinessLogicLayer.Services.Implementations;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using FilmoSearch.DataAcessLayer.DI;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FilmoSearch.BusinessLogicLayer.DI
{
    public static class ServicesConfguration
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessDependencies(configuration);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IReviewService, ReviewService>();
        }
    }
}
