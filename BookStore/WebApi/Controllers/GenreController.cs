using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Commands;
using WebApi.DBOperations;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using FluentValidation;

namespace WebApi.Controllers
{
  
    [ApiController, Route("controllerjs")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public object GetGenreDetailQueryValidator { get; private set; }

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery getGenres = new(_context, _mapper);
            return Ok(getGenres.Handle());
        }
        [HttpGet("id")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery genreDetailQuery = new(_context, _mapper);

            GetGenreDetailQueryValidator validator = new ();
            validator.ValidateAndThrow(genreDetailQuery);
            return Ok(genreDetailQuery.Handle());
        }
        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand createGenre = new(_context);
            createGenre._model = model;
            CreateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(createGenre);
            createGenre.Handle();

            return Ok();
        }
        [HttpPost("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand updateGenre = new(_context);
            updateGenre.GenreID = id;
            updateGenre._model = model;
            UpdateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(updateGenre);
            updateGenre.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand deleteGenre = new(_context);
            deleteGenre.GenreId = id;
            DeleteGenreCommandValidator validator = new();
            validator.ValidateAndThrow(deleteGenre);
            return Ok();
        }
    }
}
