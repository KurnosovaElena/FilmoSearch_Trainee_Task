namespace FilmoSearch.DataAcessLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
    }
}
