using AutoMapper;
using MovieStore.Application.Operations.Entities.Actor.ViewModels;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.Operations.Entities.Actor.Commands.Create
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            MovieStore.Entities.Actor actor =
                _context.Actors.SingleOrDefault(a => a.FirstName == Model.FirstName &&  a.LastName == Model.LastName);

            if (actor is not null)
                throw new InvalidOperationException("Oyuncu zaten mevcut.");
            

            actor = _mapper.Map<MovieStore.Entities.Actor>(Model);

            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
}
