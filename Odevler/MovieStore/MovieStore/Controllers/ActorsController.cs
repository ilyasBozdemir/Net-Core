using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [ Route("api/[controller]"), ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
          
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateActor()
        {


            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            return Ok();
        }
    }
}
