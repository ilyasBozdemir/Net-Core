using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MoviesController(IMovieStoreDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateMovie()
        {
            return Ok();
        }

        [Authorize]
        [HttpPost("{id}")]
        public IActionResult BuyMovie(int id)
        {

            return Ok();
        }

        [HttpPost("{id}/actors")]
        public IActionResult AddActor(int id)
        {

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id)
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            return Ok();
        }
    }
}
