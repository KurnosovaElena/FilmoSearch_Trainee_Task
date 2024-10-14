using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch_Trainee_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController(IFilmService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<FilmDTO>> GetAll(CancellationToken cancellationToken)
        {
            var films = await service.GetAll(cancellationToken);
            return films;
        }

        [HttpGet("{id}")]
        public async Task<FilmDTO> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var film = await service.GetById(id, cancellationToken);
            return film;
        }

        [HttpPost]
        [Authorize("change:list")]
        public async Task<FilmDTO> Add(CreateFilmDTO entity, CancellationToken cancellationToken)
        {
            var filmdto = await service.Add(entity, cancellationToken);
            return filmdto;
        }

        [HttpPut("{id}")]
        [Authorize("change:list")]
        public async Task Update(int id, CreateFilmDTO entity, CancellationToken cancellationToken)
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
