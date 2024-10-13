using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.DataAcessLayer.Repositories.Interfaces
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<IEnumerable<Actor>> GetActors(CancellationToken cancellationToken);

        Task<Actor?> GetActor(int id, CancellationToken cancellationToken);
    }
}
