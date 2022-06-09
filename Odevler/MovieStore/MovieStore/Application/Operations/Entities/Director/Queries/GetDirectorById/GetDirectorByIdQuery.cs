using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Operations.Entities.Director.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Director.Queries.GetDirectorById
{
    public class GetDirectorByIdQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorByIdQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetDirectorByIdViewModel Handle()
        {
           MovieStore.Entities. Director director = _context.Directors.Where(director => director.Id == Id)
              .Include(director => director.DirectedMovies.Where(movie => movie.isActive))
                .ThenInclude(movie => movie.Director)
              .Include(director => director.DirectedMovies.Where(movie => movie.isActive))
                .ThenInclude(movie => movie.Genre)
              .SingleOrDefault();

            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı.");
            }

            GetDirectorByIdViewModel directorVM = _mapper.Map<GetDirectorByIdViewModel>(director);
            return directorVM;
        }
    }
}
