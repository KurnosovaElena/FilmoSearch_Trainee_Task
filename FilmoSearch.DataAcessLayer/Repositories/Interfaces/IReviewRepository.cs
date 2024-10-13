using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.DataAcessLayer.Repositories.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviews(CancellationToken cancellationToken);
        Task<Review?> GetReview(int id, CancellationToken cancellationToken);
    }
}
