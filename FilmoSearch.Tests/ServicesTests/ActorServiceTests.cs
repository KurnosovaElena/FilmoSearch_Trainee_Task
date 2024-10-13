using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Exceptions;
using FilmoSearch.BusinessLogicLayer.Services.Implementations;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Moq;

namespace FilmoSearch.Tests.ServicesTests
{
    public class ActorServiceTests
    {
        private readonly Mock<IActorRepository> _actorRepositoryMock;
        private readonly Mock<IFilmRepository> _filmRepositoryMock;
        private readonly ActorService _actorService;

        public ActorServiceTests()
        {
            _actorRepositoryMock = new Mock<IActorRepository>();
            _filmRepositoryMock = new Mock<IFilmRepository>();
            _actorService = new ActorService(_actorRepositoryMock.Object, _filmRepositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ActorExists_ReturnsActorDTO()
        {
            // Arrange
            var actorId = 1;
            var actorEntity = new Actor { Id = actorId, FirstName = "Test Actor" };
            _actorRepositoryMock.Setup(repo => repo.GetActor(actorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(actorEntity);

            // Act
            var result = await _actorService.GetById(actorId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(actorId, result.Id);
            Assert.Equal("Test Actor", result.FirstName);
        }

        [Fact]
        public async Task GetById_ActorDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var actorId = 2;
            _actorRepositoryMock.Setup(repo => repo.GetActor(actorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Actor)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _actorService.GetById(actorId, CancellationToken.None));

            Assert.Equal("No actor found :(", exception.Message);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfActors()
        {
            // Arrange
            var actors = new List<Actor>
        {
            new Actor { Id = 1, FirstName = "Actor One" },
            new Actor { Id = 2, FirstName = "Actor Two" }
        };
            _actorRepositoryMock.Setup(repo => repo.GetActors(It.IsAny<CancellationToken>()))
                .ReturnsAsync(actors);

            // Act
            var result = await _actorService.GetAll(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Add_ValidActor_AddsAndReturnsActorDTO()
        {
            // Arrange
            var createActorDto = new CreateActorDTO { FirstName = "New Actor" };
            var actorEntity = new Actor { Id = 3, FirstName = "New Actor" };
            _actorRepositoryMock.Setup(repo => repo.Add(It.IsAny<Actor>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            _filmRepositoryMock.Setup(repo => repo.GetFilm(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Film)null);

            // Act
            var result = await _actorService.Add(createActorDto, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Actor", result.FirstName);
        }

        [Fact]
        public async Task Add_InvalidFilm_ThrowsBadRequestException()
        {
            // Arrange
            var createActorDto = new CreateActorDTO
            {
                FirstName = "New Actor",
                Films = [new Film {
                    Id = 999
                }]
            };

            _filmRepositoryMock.Setup(repo => repo.GetFilm(999, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Film)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _actorService.Add(createActorDto, CancellationToken.None));

        }

        [Fact]
        public async Task Update_ActorExists_UpdatesActor()
        {
            // Arrange
            var actorId = 1;
            var existingActor = new Actor { Id = actorId, FirstName = "Old Actor" };
            var updateDto = new CreateActorDTO { FirstName = "Updated Actor" };

            _actorRepositoryMock.Setup(repo => repo.GetActor(actorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingActor);

            // Act
            await _actorService.Update(actorId, updateDto, CancellationToken.None);

            // Assert
            _actorRepositoryMock.Verify(repo => repo.Update(existingActor, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal("Updated Actor", existingActor.FirstName);
        }

        [Fact]
        public async Task Update_ActorDoesNotExist_ThrowsBadRequestException()
        {
            // Arrange
            var actorId = 2;
            var updateDto = new CreateActorDTO { FirstName = "Updated Actor" };

            _actorRepositoryMock.Setup(repo => repo.GetActor(actorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Actor)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _actorService.Update(actorId, updateDto, CancellationToken.None));

            Assert.Equal("No such actor :(", exception.Message);
        }

        [Fact]
        public async Task Delete_ActorExists_DeletesActor()
        {
            // Arrange
            var actorId = 1;
            var existingActor = new Actor { Id = actorId, FirstName = "Actor to Delete" };

            _actorRepositoryMock.Setup(repo => repo.GetActor(actorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingActor);

            // Act
            await _actorService.Delete(actorId, CancellationToken.None);

            // Assert
            _actorRepositoryMock.Verify(repo => repo.Delete(existingActor, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ActorDoesNotExist_ThrowsBadRequestException()
        {
            // Arrange
            var actorId = 2;

            _actorRepositoryMock.Setup(repo => repo.GetActor(actorId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Actor)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
                _actorService.Delete(actorId, CancellationToken.None));

            Assert.Equal("No such actor :(", exception.Message);
        }
    }
}
