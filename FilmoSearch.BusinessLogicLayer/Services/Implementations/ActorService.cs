using FilmoSearch.BusinessLogicLayer.DataTransferObjects;
using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Exceptions;
using FilmoSearch.BusinessLogicLayer.Services.Interfaces;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Mapster;

namespace FilmoSearch.BusinessLogicLayer.Services.Implementations
{
    public class ActorService(IActorRepository repository, IFilmRepository filmRepository) : IActorService
    {
        public async Task<ActorDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var actorModel = await repository.GetActor(id, cancellationToken)
                ?? throw new NotFoundException("No actor found :(");

            var actorDto = actorModel.Adapt<ActorDTO>();

            return actorDto;
        }
        public async Task<IEnumerable<ActorDTO>> GetAll(CancellationToken cancellationToken)
        {
            var actorsModel = await repository.GetActors(cancellationToken);

            var actorsDto = actorsModel.Adapt<IEnumerable<ActorDTO>>();

            return actorsDto;
        }
        public async Task<ActorDTO> Add(CreateActorDTO entity, CancellationToken cancellationToken)
        {
            var actor = entity.Adapt<CreateActorDTO, Actor>();

            if (actor.Films is not null && actor.Films.Any())
            {
                var films = new List<Film>();

                foreach (var actorFilm in actor.Films)
                {
                    var film = await filmRepository.GetFilm(actorFilm.Id, cancellationToken)
                        ?? throw new BadRequestException("No such film :(");

                    films.Add(film);
                }

                actor.Films = films;

            }

            await repository.Add(actor, cancellationToken);

            var actorDto = actor.Adapt<ActorDTO>();

            return actorDto;
        }
        public async Task Update(int id, CreateActorDTO entity, CancellationToken cancellationToken)
        {
            var oldEntity = await repository.GetActor(id, cancellationToken)
                ?? throw new BadRequestException("No such actor :(");

            entity.Adapt(oldEntity);

            await repository.Update(oldEntity, cancellationToken);
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await repository.GetActor(id, cancellationToken)
            ?? throw new BadRequestException("No such actor :(");

            await repository.Delete(entity, cancellationToken);
        }
    }
}
