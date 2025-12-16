using System;
using System.Collections.Generic;
using GameStore.Controllers;
using GameStore.DTOs;
using GameStore.Models;
using GameStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameStore.Tests.Controllers
{
    /// <summary>
    /// Unit tests for VideoGamesController.
    /// </summary>
    public class VideoGamesControllerTests
    {
        [Fact]
        public void GetAll_ReturnsAllGames()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            mockRepo.Setup(r => r.GetAll()).Returns(new List<VideoGame> { new VideoGame { Id = 1, Title = "A", Genre = "G", ReleaseDate = DateTime.Today } });
            var controller = new VideoGamesController(mockRepo.Object);
            var result = controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var games = Assert.IsAssignableFrom<IEnumerable<VideoGame>>(okResult.Value);
            Assert.Single(games);
        }

        [Fact]
        public void GetById_ReturnsGame_WhenFound()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns(new VideoGame { Id = 1 });
            var controller = new VideoGamesController(mockRepo.Object);
            var result = controller.GetById(1);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(1, ((VideoGame)okResult.Value).Id);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenMissing()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns((VideoGame)null);
            var controller = new VideoGamesController(mockRepo.Object);
            var result = controller.GetById(1);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_AddsGameAndReturnsCreated()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            VideoGame added = null;
            mockRepo.Setup(r => r.Add(It.IsAny<VideoGame>())).Callback<VideoGame>(g => { g.Id = 42; added = g; });
            var controller = new VideoGamesController(mockRepo.Object);
            var dto = new VideoGameDto { Title = "T", Genre = "G", ReleaseDate = DateTime.Today };
            var result = controller.Create(dto);
            var created = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(42, ((VideoGame)created.Value).Id);
            Assert.NotNull(added);
        }

        [Fact]
        public void Update_UpdatesGame_WhenFound()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            var existing = new VideoGame { Id = 1, Title = "Old", Genre = "G", ReleaseDate = DateTime.Today };
            mockRepo.Setup(r => r.GetById(1)).Returns(existing);
            var controller = new VideoGamesController(mockRepo.Object);
            var dto = new VideoGameDto { Title = "New", Genre = "G", ReleaseDate = DateTime.Today };
            var result = controller.Update(1, dto);
            Assert.IsType<NoContentResult>(result);
            Assert.Equal("New", existing.Title);
        }

        [Fact]
        public void Update_ReturnsNotFound_WhenMissing()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns((VideoGame)null);
            var controller = new VideoGamesController(mockRepo.Object);
            var dto = new VideoGameDto { Title = "T", Genre = "G", ReleaseDate = DateTime.Today };
            var result = controller.Update(1, dto);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_DeletesGame_WhenFound()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            var existing = new VideoGame { Id = 1 };
            mockRepo.Setup(r => r.GetById(1)).Returns(existing);
            var controller = new VideoGamesController(mockRepo.Object);
            var result = controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenMissing()
        {
            var mockRepo = new Mock<IVideoGameRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns((VideoGame)null);
            var controller = new VideoGamesController(mockRepo.Object);
            var result = controller.Delete(1);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}