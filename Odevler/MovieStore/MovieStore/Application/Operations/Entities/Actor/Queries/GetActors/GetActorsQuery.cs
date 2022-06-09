using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Operations.Entities.Actor.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Actor.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            List<MovieStore.Entities.Actor> actors = _context.Actors
            .Include(actor => actor.Movies.Where(movie => movie.isActive))
              .ThenInclude(movie => movie.Director)
            .Include(actor => actor.Movies.Where(movie => movie.isActive))
              .ThenInclude(movie => movie.Genre)
            .OrderBy(actor => actor.Id)
            .ToList<MovieStore.Entities.Actor>();

            List<ActorsViewModel> actorsVM = _mapper.Map<List<ActorsViewModel>>(actors);

            return actorsVM;
        }
    }
}
