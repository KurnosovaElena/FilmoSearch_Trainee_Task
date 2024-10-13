using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;

namespace FilmoSearch.BusinessLogicLayer.Services.Interfaces
{
    public interface IFilmService
    {
        Task<FilmDTO> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<FilmDTO>> GetAll(CancellationToken cancellationToken);
        Task<FilmDTO> Add(CreateFilmDTO entity, CancellationToken cancellationToken);
        Task Update(int id, CreateFilmDTO entity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
