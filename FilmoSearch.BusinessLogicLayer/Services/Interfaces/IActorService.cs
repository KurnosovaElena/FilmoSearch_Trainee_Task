using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;

namespace FilmoSearch.BusinessLogicLayer.Services.Interfaces
{
    public interface IActorService
    {
        Task<ActorDTO> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ActorDTO>> GetAll(CancellationToken cancellationToken);
        Task<ActorDTO> Add(CreateActorDTO entity, CancellationToken cancellationToken);
        Task Update(int id, CreateActorDTO entity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
