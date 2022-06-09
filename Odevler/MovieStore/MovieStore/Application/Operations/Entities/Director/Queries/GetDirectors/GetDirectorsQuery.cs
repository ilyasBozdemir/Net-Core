using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Operations.Entities.Director.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Director.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorsViewModel> Handle()
        {
            List<MovieStore.Entities.Director> directors = _context.Directors.Include(director => director.DirectedMovies.Where(movie => movie.isActive)).ThenInclude(movie => movie. Genre).OrderBy(director => director.Id).ToList<MovieStore.Entities.Director>();
            return _mapper.Map<List<DirectorsViewModel>>(directors);
             
        }

    }
}
