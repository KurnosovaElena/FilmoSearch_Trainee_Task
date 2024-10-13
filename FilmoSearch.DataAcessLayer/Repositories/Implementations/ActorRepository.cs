using FilmoSearch.DataAcessLayer.Context;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch.DataAcessLayer.Repositories.Implementations
{
    public class ActorRepository(PortalContext portalContext) : Repository<Actor>(portalContext), IActorRepository
    {
        public async Task<IEnumerable<Actor>> GetActors(CancellationToken cancellationToken)
        {
            var actors = await portalContext.Actors.ToListAsync(cancellationToken);
            return actors;
        }

        public async Task<Actor?> GetActor(int id, CancellationToken cancellationToken)
        {
            var actor = await portalContext.Actors.Include(a => a.Films).FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            return actor;
        }
    }
}
