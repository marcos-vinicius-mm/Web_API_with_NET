using Movies_API.Models;
using Microsoft.AspNetCore.Mvc;
using Movies_API.Data;
using Movies_API.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Movies_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController: ControllerBase
    {

        private MovieContext _context;
        private IMapper _mapper;
        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adicionar Filme ao catálogo
        /// </summary>
        /// <param name="movieDTO">
        /// Objeto com os atributos para a criação do filme
        /// </param>
        /// <returns> IActionResult </returns>
        /// <response code="201">Caso haja inserção bem-sucedida</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddFilm([FromBody] CreateMovieDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(
                nameof(PullMovieById), 
                new {id = movie.ID},
                movie
            );

        }

        /// <summary>
        /// Listar Filmes existentes no catálogo
        /// </summary>
        /// <param name="skip"></param>
        /// skip = índice do filme inicial da consulta, com base na última consulta
        /// take = quantidade de filmes consultados
        /// <param name="take"></param>
        /// <returns> IEnumerable<ReadMovieDTO> </returns>
        /// <response code="204">Caso a consulta seja bem-sucedida</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IEnumerable<ReadMovieDTO> PullMovies([FromQuery] int skip=0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take));
        }

        /// <summary>
        /// Listar Filme com base no ID
        /// </summary>
        /// <param name="id">
        ///     Indenticador único do filme dentro do catálogo
        /// </param>
        /// <returns> IActionResult </returns>
        /// <response code="204">Caso o filme exista no catálogo e a consulta seja bem-sucedida</response>
        /// <response code="404">Caso o filme não exista no catálogo ou tenha ocorrido erro durante a consulta</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PullMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if(movie == null) return NotFound();
            var movieDTO = _mapper.Map<ReadMovieDTO>(movie);
            return Ok(movieDTO);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO updateMovieDTO)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if (movie== null) return NotFound();
            _mapper.Map(updateMovieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateMovie(int id, [FromBody] JsonPatchDocument<UpdateMovieDTO> patch)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if (movie == null) return NotFound();

            var movieForUpdate = _mapper.Map<UpdateMovieDTO>(movie);

            patch.ApplyTo(movieForUpdate, ModelState);
            if (!TryValidateModel(movieForUpdate)) return ValidationProblem(ModelState);

            _mapper.Map(movieForUpdate, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if (movie == null) return NotFound();
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
