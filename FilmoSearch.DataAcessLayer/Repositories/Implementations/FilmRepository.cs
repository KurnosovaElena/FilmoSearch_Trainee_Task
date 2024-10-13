using FilmoSearch.DataAcessLayer.Context;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch.DataAcessLayer.Repositories.Implementations
{
    public class FilmRepository(PortalContext portalContext) : Repository<Film>(portalContext), IFilmRepository
    {
        public async Task<IEnumerable<Film>> GetFilms(CancellationToken cancellationToken)
        {
            var films = await portalContext.Films.ToListAsync(cancellationToken);
            return films;
        }
        public async Task<Film?> GetFilm(int id, CancellationToken cancellationToken)
        {
            var film = await portalContext.Films.Include(f => f.Reviews).Include(f => f.Actors).FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
            return film;
        }
    }
}
