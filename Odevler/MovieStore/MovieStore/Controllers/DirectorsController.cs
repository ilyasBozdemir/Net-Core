using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Operations.Entities.Director.Commands.Create;
using MovieStore.Application.Operations.Entities.Director.Commands.Delete;
using MovieStore.Application.Operations.Entities.Director.Commands.Update;
using MovieStore.Application.Operations.Entities.Director.Queries.GetDirectorById;
using MovieStore.Application.Operations.Entities.Director.Queries.GetDirectors;
using MovieStore.Application.Operations.Entities.Director.ViewModels;
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
            GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
            List<DirectorsViewModel> result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDirectorById(int id)
        {
            GetDirectorByIdQuery query = new GetDirectorByIdQuery(_context, _mapper);
            query.Id = id;

            GetDirectorByIdQueryValidator validator = new GetDirectorByIdQueryValidator();
            validator.ValidateAndThrow(query);

            GetDirectorByIdViewModel result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = newDirector;

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel updatedDirector)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);

            command.Id = id;
            command.Model = updatedDirector;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);

            command.Id = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}
