using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Operations.Entities.Actor.Queries.GetActorById;
using MovieStore.Application.Operations.Entities.Actor.Queries.GetActors;
using MovieStore.Application.Operations.Entities.Actor.ViewModels;
using MovieStore.DBOperations;
using FluentValidation;
using MovieStore.Application.Operations.Entities.Actor.Commands.Create;
using MovieStore.Application.Operations.Entities.Actor.Commands.Update;
using MovieStore.Application.Operations.Entities.Actor.Commands.Delete;

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
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            List<ActorsViewModel> result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
            GetActorByIdQuery query = new GetActorByIdQuery(_context, _mapper);
            query.Id = id;

            GetActorByIdQueryValidator validator = new GetActorByIdQueryValidator();
            validator.ValidateAndThrow(query);

            GetActorByIdViewModel result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = newActor;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel updatedActor)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);

            command.Id = id;
            command.Model = updatedActor;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);

            command.Id = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}
