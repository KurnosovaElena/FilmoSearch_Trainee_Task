using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Exceptions;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Mapster;

namespace FilmoSearch.BusinessLogicLayer.Services.Implementations
{
    public class FilmService(IFilmRepository repository) : IFilmService
    {
        public async Task<FilmDTO> Add(CreateFilmDTO entity, CancellationToken cancellationToken)
        {
            var film = entity.Adapt<CreateFilmDTO, Film>()
            ?? throw new NotFoundException("No film found :(");

            await repository.Add(film, cancellationToken);

            var filmDTO = film.Adapt<FilmDTO>();

            return filmDTO;

        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var film = await repository.GetFilm(id, cancellationToken)
                ?? throw new NotFoundException("No film found :(");

            await repository.Delete(film, cancellationToken);
        }

        public async Task<IEnumerable<FilmDTO>> GetAll(CancellationToken cancellationToken)
        {
            var filmsModel = await repository.GetFilms(cancellationToken);
            var filmsDTO = filmsModel.Adapt<IEnumerable<FilmDTO>>();
            return filmsDTO;
        }

        public async Task<FilmDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var filmModel = await repository.GetFilm(id, cancellationToken)
                ?? throw new NotFoundException("No film found :(");

            var filmDTO = filmModel.Adapt<FilmDTO>();
            return filmDTO;
        }

        public async Task Update(int id, CreateFilmDTO entity, CancellationToken cancellationToken)
        {
            var filmDTO = await repository.GetFilm(id, cancellationToken)
                ?? throw new NotFoundException("No film found :(");

            entity.Adapt(filmDTO);

            await repository.Update(filmDTO, cancellationToken);
        }
    }
}
