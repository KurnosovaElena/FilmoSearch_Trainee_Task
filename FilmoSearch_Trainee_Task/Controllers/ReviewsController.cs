using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch_Trainee_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController(IReviewService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ReviewDTO>> GetAll(CancellationToken cancellationToken)
        {
            var reviews = await service.GetAll(cancellationToken);
            return reviews;
        }

        [HttpGet("{id}")]
        public async Task<ReviewDTO> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var review = await service.GetById(id, cancellationToken);
            return review;
        }

        [HttpPost]
        [Authorize("change:list")]
        public async Task<ReviewDTO> Add([FromBody] CreateReviewDTO entity, CancellationToken cancellationToken)
        {
            var reviewDTO = await service.Add(entity, cancellationToken);
            return reviewDTO;
        }

        [HttpPut("{id}")]
        [Authorize("change:list")]
        public async Task Update(int id, CreateReviewDTO entity, CancellationToken cancellationToken)
        {
            await service.Update(id, entity, cancellationToken);
        }

        [HttpDelete("{id}")]
        [Authorize("change:list")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await service.Delete(id, cancellationToken);
        }
    }
}
