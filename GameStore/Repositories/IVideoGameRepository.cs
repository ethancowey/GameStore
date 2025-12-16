using System.Collections.Generic;
using GameStore.Models;

namespace GameStore.Repositories
{
    /// <summary>
    /// Interface for videogame repository.
    /// </summary>
    public interface IVideoGameRepository
    {
        /// <summary>
        /// Gets all videogames.
        /// </summary>
        IEnumerable<VideoGame> GetAll();

        /// <summary>
        /// Gets a videogame by its ID.
        /// </summary>
        VideoGame GetById(int id);

        /// <summary>
        /// Adds a new videogame.
        /// </summary>
        void Add(VideoGame game);

        /// <summary>
        /// Updates an existing videogame.
        /// </summary>
        void Update(VideoGame game);

        /// <summary>
        /// Deletes a videogame by its ID.
        /// </summary>
        void Delete(int id);
    }
}