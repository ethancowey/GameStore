using System;

namespace GameStore.DTOs
{
    /// <summary>
    /// Data Transfer Object for creating or updating a videogame.
    /// </summary>
    public class VideoGameDto
    {
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