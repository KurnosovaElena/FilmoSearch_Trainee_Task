using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Exceptions;
using FilmoSearch.BusinessLogicLayer.Services.Implementations;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Moq;

namespace FilmoSearch.Tests.ServicesTests
{
    public class FilmServiceTests
    {
        private readonly Mock<IFilmRepository> _filmRepositoryMock;
        private readonly FilmService _filmService;

        public FilmServiceTests()
        {
            _filmRepositoryMock = new Mock<IFilmRepository>();
            _filmService = new FilmService(_filmRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ValidFilm_AddsAndReturnsFilmDTO()
        {
            // Arrange
            var createFilmDto = new CreateFilmDTO { Title = "New Film" };
            var filmEntity = new Film { Id = 1, Title = "New Film" };

            _filmRepositoryMock.Setup(repo => repo.Add(It.IsAny<Film>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _filmService.Add(createFilmDto, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Film", result.Title);
        }

        [Fact]
        public async Task Delete_FilmExists_DeletesFilm()
        {
            // Arrange
            var filmId = 1;
            var filmEntity = new Film { Id = filmId, Title = "Film to Delete" };

            _filmRepositoryMock.Setup(repo => repo.GetFilm(filmId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(filmEntity);

            // Act
            await _filmService.Delete(filmId, CancellationToken.None);

            // Assert
            _filmRepositoryMock.Verify(repo => repo.Delete(filmEntity, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_FilmDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var filmId = 2;

            _filmRepositoryMock.Setup(repo => repo.GetFilm(filmId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Film)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _filmService.Delete(filmId, CancellationToken.None));

            Assert.Equal("No film found :(", exception.Message);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfFilms()
        {
            // Arrange
            var films = new List<Film>
        {
            new Film { Id = 1, Title = "Film One" },
            new Film { Id = 2, Title = "Film Two" }
        };
            _filmRepositoryMock.Setup(repo => repo.GetFilms(It.IsAny<CancellationToken>()))
                .ReturnsAsync(films);

            // Act
            var result = await _filmService.GetAll(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetById_FilmExists_ReturnsFilmDTO()
        {
            // Arrange
            var filmId = 1;
            var filmEntity = new Film { Id = filmId, Title = "Test Film" };
            _filmRepositoryMock.Setup(repo => repo.GetFilm(filmId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(filmEntity);

            // Act
            var result = await _filmService.GetById(filmId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(filmId, result.Id);
            Assert.Equal("Test Film", result.Title);
        }

        [Fact]
        public async Task GetById_FilmDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var filmId = 2;

            _filmRepositoryMock.Setup(repo => repo.GetFilm(filmId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Film)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _filmService.GetById(filmId, CancellationToken.None));

            Assert.Equal("No film found :(", exception.Message);
        }

        [Fact]
        public async Task Update_FilmExists_UpdatesFilm()
        {
            // Arrange
            var filmId = 1;
            var existingFilm = new Film { Id = filmId, Title = "Old Film" };
            var updateDto = new CreateFilmDTO { Title = "Updated Film" };

            _filmRepositoryMock.Setup(repo => repo.GetFilm(filmId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingFilm);

            // Act
            await _filmService.Update(filmId, updateDto, CancellationToken.None);

            // Assert
            _filmRepositoryMock.Verify(repo => repo.Update(existingFilm, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal("Updated Film", existingFilm.Title);
        }

        [Fact]
        public async Task Update_FilmDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var filmId = 2;
            var updateDto = new CreateFilmDTO { Title = "Updated Film" };

            _filmRepositoryMock.Setup(repo => repo.GetFilm(filmId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Film)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _filmService.Update(filmId, updateDto, CancellationToken.None));

            Assert.Equal("No film found :(", exception.Message);
        }
    }
}