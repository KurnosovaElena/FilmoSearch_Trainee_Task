using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch_Trainee_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorsController(IActorService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> GetAll(CancellationToken cancellationToken)
        {
            var actors = await service.GetAll(cancellationToken);
            return actors;
        }

        [HttpGet("{id}")]
        public async Task<ActorDTO> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var actor = await service.GetById(id, cancellationToken);
            return actor;
        }

        [HttpPost]
        [Authorize("change:list")]
        public async Task<ActorDTO> Add(CreateActorDTO entity, CancellationToken cancellationToken)
        {
            var actordto = await service.Add(entity, cancellationToken);

            return actordto;
        }

        [HttpPut("{id}")]
        [Authorize("change:list")]
        public async Task Update(int id, CreateActorDTO entity, CancellationToken cancellationToken)
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