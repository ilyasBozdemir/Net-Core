using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Operations.Entities.Actor.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Actor.Queries.GetActorById
{
    public class GetActorByIdQuery
    {
        public int Id { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorByIdQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ViewModels.GetActorByIdViewModel Handle()
        {
            MovieStore.Entities.Actor actor = _context.Actors.Where(actor => actor.Id == Id)
            .Include(actor => actor.Movies.Where(movie => movie.isActive))
              .ThenInclude(movie => movie.Director)
            .Include(actor => actor.Movies.Where(movie => movie.isActive))
              .ThenInclude(movie => movie.Genre)
            .SingleOrDefault();

            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadı.");
            }
            GetActorByIdViewModel actorVM = _mapper.Map<GetActorByIdViewModel>(actor);
            return actorVM;
        }
    }
}
