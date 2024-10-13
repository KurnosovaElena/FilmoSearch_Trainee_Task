using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;

namespace FilmoSearch.BusinessLogicLayer.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDTO> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ReviewDTO>> GetAll(CancellationToken cancellationToken);
        Task<ReviewDTO> Add(CreateReviewDTO entity, CancellationToken cancellationToken);
        Task Update(int id, CreateReviewDTO entity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
