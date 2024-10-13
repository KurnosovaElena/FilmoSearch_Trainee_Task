using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Exceptions;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Mapster;

namespace FilmoSearch.BusinessLogicLayer.Services.Implementations
{
    public class ReviewService(IReviewRepository repository) : IReviewService
    {
        public async Task<ReviewDTO> Add(CreateReviewDTO entity, CancellationToken cancellationToken)
        {
            var review = entity.Adapt<CreateReviewDTO, Review>()
                ?? throw new NotFoundException("No review found :(");

            await repository.Add(review, cancellationToken);

            var reviewDTO = review.Adapt<ReviewDTO>();

            return reviewDTO;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var review = await repository.GetReview(id, cancellationToken)
                ?? throw new NotFoundException("No review found :(");
            await repository.Delete(review, cancellationToken);
        }

        public async Task<IEnumerable<ReviewDTO>> GetAll(CancellationToken cancellationToken)
        {
            var reviewsModel = await repository.GetReviews(cancellationToken);
            var reviewsDTO = reviewsModel.Adapt<IEnumerable<ReviewDTO>>();
            return reviewsDTO;
        }

        public async Task<ReviewDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var reviewModel = await repository.GetReview(id, cancellationToken)
                ?? throw new NotFoundException("No review found :(");
            var reviewDTO = reviewModel.Adapt<ReviewDTO>();
            return reviewDTO;
        }

        public async Task Update(int id, CreateReviewDTO entity, CancellationToken cancellationToken)
        {
            var reviewDTO = await repository.GetReview(id, cancellationToken)
                ?? throw new NotFoundException("No review found :(");
            entity.Adapt(reviewDTO);
            await repository.Update(reviewDTO, cancellationToken);
        }
    }
}
