using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class DirectorsController : ControllerBase
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public DirectorsController(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDirectors()
    {
     
      return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetDirectorById(int id)
    {
            return Ok();
    }

    [HttpPost]
    public IActionResult CreateDirector( )
    {
      
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirector(int id)
    {
       return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDirector(int id)
    {
      return Ok();
    }
  }
}
