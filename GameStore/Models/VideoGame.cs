using System;

namespace GameStore.Models
{
    /// <summary>
    /// Represents a videogame in the library.
    /// </summary>
    public class VideoGame
    {
        /// <summary>
        /// The unique identifier for the videogame.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the videogame.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The genre of the videogame.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// The release date of the videogame.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}