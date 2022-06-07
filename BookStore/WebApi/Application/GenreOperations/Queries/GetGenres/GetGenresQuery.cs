using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{

    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context;
        public IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(genre => genre.IsActive).OrderBy(genre => genre.Id);
            List<GenreViewModel> returnObj = _mapper.Map<List<GenreViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
    }
}

