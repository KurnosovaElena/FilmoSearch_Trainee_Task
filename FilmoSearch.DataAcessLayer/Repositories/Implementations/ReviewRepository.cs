using FilmoSearch.DataAcessLayer.Context;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch.DataAcessLayer.Repositories.Implementations
{
    public class ReviewRepository(PortalContext portalContext) : Repository<Review>(portalContext), IReviewRepository
    {
        public async Task<IEnumerable<Review>> GetReviews(CancellationToken cancellationToken)
        {
            var reviews = await portalContext.Reviews.ToListAsync(cancellationToken);
            return reviews;
        }
        public async Task<Review?> GetReview(int id, CancellationToken cancellationToken)
        {
            var review = await portalContext.Reviews.Include(r => r.Film).FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
            return review;
        }
    }
}
