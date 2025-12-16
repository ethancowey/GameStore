using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GameStore.Models;
using GameStore.DTOs;
using GameStore.Repositories;

namespace GameStore.Controllers
{
    /// <summary>
    /// Controller for managing videogames in the library.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGamesController"/> class.
        /// </summary>
        /// <param name="repository">The videogame repository.</param>
        public VideoGamesController(IVideoGameRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all videogames.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<VideoGame>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        /// <summary>
        /// Gets a videogame by ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetById(int id)
        {
            var game = _repository.GetById(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        /// <summary>
        /// Adds a new videogame.
        /// </summary>
        [HttpPost]
        public ActionResult<VideoGame> Create(VideoGameDto dto)
        {
            var game = new VideoGame
            {
                Title = dto.Title,
                Genre = dto.Genre,
                ReleaseDate = dto.ReleaseDate
            };
            _repository.Add(game);
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        /// <summary>
        /// Updates an existing videogame.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, VideoGameDto dto)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();
            existing.Title = dto.Title;
            existing.Genre = dto.Genre;
            existing.ReleaseDate = dto.ReleaseDate;
            _repository.Update(existing);
            return NoContent();
        }

        /// <summary>
        /// Deletes a videogame by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();
            _repository.Delete(id);
            return NoContent();
        }
    }
}