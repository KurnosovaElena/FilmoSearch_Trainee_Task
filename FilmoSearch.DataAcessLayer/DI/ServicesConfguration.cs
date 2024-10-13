using FilmoSearch.DataAcessLayer.Context;
using FilmoSearch.DataAcessLayer.Repositories.Implementations;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmoSearch.DataAcessLayer.DI
{
    public static class ServicesConfguration
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalContext>(options => options.UseNpgsql(configuration.GetConnectionString("DBConnection")));

            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IFilmRepository, FilmRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
        }
    }
}
