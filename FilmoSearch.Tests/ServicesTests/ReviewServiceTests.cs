using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FilmoSearch.BusinessLogicLayer.Exceptions;
using FilmoSearch.BusinessLogicLayer.Services.Implementations;
using FilmoSearch.DataAcessLayer.Entities;
using FilmoSearch.DataAcessLayer.Repositories.Interfaces;
using Moq;

namespace FilmoSearch.Tests.ServicesTests
{
    public class ReviewServiceTests
    {
        private readonly Mock<IReviewRepository> _reviewRepositoryMock;
        private readonly ReviewService _reviewService;

        public ReviewServiceTests()
        {
            _reviewRepositoryMock = new Mock<IReviewRepository>();
            _reviewService = new ReviewService(_reviewRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ValidReview_AddsAndReturnsReviewDTO()
        {
            // Arrange
            var createReviewDto = new CreateReviewDTO { Description = "Great movie!" };
            var reviewEntity = new Review { Id = 1, Description = "Great movie!" };

            _reviewRepositoryMock.Setup(repo => repo.Add(It.IsAny<Review>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _reviewService.Add(createReviewDto, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Great movie!", result.Description);
        }

        [Fact]
        public async Task Delete_ReviewExists_DeletesReview()
        {
            // Arrange
            var reviewId = 1;
            var reviewEntity = new Review { Id = reviewId, Description = "Review to delete" };

            _reviewRepositoryMock.Setup(repo => repo.GetReview(reviewId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(reviewEntity);

            // Act
            await _reviewService.Delete(reviewId, CancellationToken.None);

            // Assert
            _reviewRepositoryMock.Verify(repo => repo.Delete(reviewEntity, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ReviewDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var reviewId = 2;

            _reviewRepositoryMock.Setup(repo => repo.GetReview(reviewId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Review)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _reviewService.Delete(reviewId, CancellationToken.None));

            Assert.Equal("No review found :(", exception.Message);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfReviews()
        {
            // Arrange
            var reviews = new List<Review>
        {
            new Review { Id = 1, Description = "Review One" },
            new Review { Id = 2, Description = "Review Two" }
        };
            _reviewRepositoryMock.Setup(repo => repo.GetReviews(It.IsAny<CancellationToken>()))
                .ReturnsAsync(reviews);

            // Act
            var result = await _reviewService.GetAll(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetById_ReviewExists_ReturnsReviewDTO()
        {
            // Arrange
            var reviewId = 1;
            var reviewEntity = new Review { Id = reviewId, Description = "Test Review" };
            _reviewRepositoryMock.Setup(repo => repo.GetReview(reviewId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(reviewEntity);

            // Act
            var result = await _reviewService.GetById(reviewId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reviewId, result.Id);
            Assert.Equal("Test Review", result.Description);
        }

        [Fact]
        public async Task GetById_ReviewDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var reviewId = 2;

            _reviewRepositoryMock.Setup(repo => repo.GetReview(reviewId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Review)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _reviewService.GetById(reviewId, CancellationToken.None));

            Assert.Equal("No review found :(", exception.Message);
        }

        [Fact]
        public async Task Update_ReviewExists_UpdatesReview()
        {
            // Arrange
            var reviewId = 1;
            var existingReview = new Review { Id = reviewId, Description = "Old Review" };
            var updateDto = new CreateReviewDTO { Description = "Updated Review" };

            _reviewRepositoryMock.Setup(repo => repo.GetReview(reviewId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingReview);

            // Act
            await _reviewService.Update(reviewId, updateDto, CancellationToken.None);

            // Assert
            _reviewRepositoryMock.Verify(repo => repo.Update(existingReview, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal("Updated Review", existingReview.Description);
        }

        [Fact]
        public async Task Update_ReviewDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var reviewId = 2;
            var updateDto = new CreateReviewDTO { Description = "Updated Review" };

            _reviewRepositoryMock.Setup(repo => repo.GetReview(reviewId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Review)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() =>
                _reviewService.Update(reviewId, updateDto, CancellationToken.None));

            Assert.Equal("No review found :(", exception.Message);
        }
    }
}