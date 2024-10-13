using FilmoSearch.DataAcessLayer.Context;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;

namespace FilmoSearch.DataAcessLayer.Repositories.Implementations
{
    public class Repository<T>(PortalContext portalContext) : IRepository<T> where T : class
    {
        public async Task Add(T entity, CancellationToken cancellationToken)
        {
            await portalContext.AddAsync(entity, cancellationToken);
            await portalContext.SaveChangesAsync(cancellationToken);
        }
        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            portalContext.Update(entity);
            await portalContext.SaveChangesAsync(cancellationToken);
        }
        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            portalContext.Remove(entity);
            await portalContext.SaveChangesAsync(cancellationToken);
        }
    }
}
