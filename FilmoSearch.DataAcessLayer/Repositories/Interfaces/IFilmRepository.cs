using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.DataAcessLayer.Repositories.Interfaces
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<IEnumerable<Film>> GetFilms(CancellationToken cancellationToken);
        Task<Film?> GetFilm(int id, CancellationToken cancellationToken);
    }
}
