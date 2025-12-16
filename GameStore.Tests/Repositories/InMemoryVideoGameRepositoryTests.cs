using System;
using System.Collections.Generic;
using GameStore.Models;
using GameStore.Repositories;
using Xunit;

namespace GameStore.Tests.Repositories
{
    /// <summary>
    /// Unit tests for InMemoryVideoGameRepository.
    /// </summary>
    public class InMemoryVideoGameRepositoryTests
    {
        [Fact]
        public void Add_ShouldAssignIdAndStoreGame()
        {
            var repo = new InMemoryVideoGameRepository();
            var game = new VideoGame { Title = "Test", Genre = "Action", ReleaseDate = DateTime.Today };
            repo.Add(game);
            Assert.Equal(1, game.Id);
            Assert.Single(repo.GetAll());
        }

        [Fact]
        public void GetById_ShouldReturnCorrectGame()
        {
            var repo = new InMemoryVideoGameRepository();
            var game = new VideoGame { Title = "Test", Genre = "Action", ReleaseDate = DateTime.Today };
            repo.Add(game);
            var result = repo.GetById(game.Id);
            Assert.Equal(game, result);
        }

        [Fact]
        public void Update_ShouldModifyGame()
        {
            var repo = new InMemoryVideoGameRepository();
            var game = new VideoGame { Title = "Test", Genre = "Action", ReleaseDate = DateTime.Today };
            repo.Add(game);
            game.Title = "Updated";
            repo.Update(game);
            Assert.Equal("Updated", repo.GetById(game.Id).Title);
        }

        [Fact]
        public void Delete_ShouldRemoveGame()
        {
            var repo = new InMemoryVideoGameRepository();
            var game = new VideoGame { Title = "Test", Genre = "Action", ReleaseDate = DateTime.Today };
            repo.Add(game);
            repo.Delete(game.Id);
            Assert.Empty(repo.GetAll());
        }
    }
}