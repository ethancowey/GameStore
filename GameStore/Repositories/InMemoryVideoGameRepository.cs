using System.Collections.Generic;
using System.Linq;
using GameStore.Models;

namespace GameStore.Repositories
{
    /// <summary>
    /// In-memory implementation of the videogame repository.
    /// </summary>
    public class InMemoryVideoGameRepository : IVideoGameRepository
    {
        private readonly List<VideoGame> _games = new List<VideoGame>();
        private int _nextId = 1;

        public IEnumerable<VideoGame> GetAll() => _games;

        public VideoGame GetById(int id) => _games.FirstOrDefault(g => g.Id == id);

        public void Add(VideoGame game)
        {
            game.Id = _nextId++;
            _games.Add(game);
        }

        public void Update(VideoGame game)
        {
            var existing = GetById(game.Id);
            if (existing != null)
            {
                existing.Title = game.Title;
                existing.Genre = game.Genre;
                existing.ReleaseDate = game.ReleaseDate;
            }
        }

        public void Delete(int id)
        {
            var game = GetById(id);
            if (game != null)
            {
                _games.Remove(game);
            }
        }
    }
}