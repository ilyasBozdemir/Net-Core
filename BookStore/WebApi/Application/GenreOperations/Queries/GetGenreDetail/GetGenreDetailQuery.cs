using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public readonly BookStoreDbContext _context;
        public IMapper _mapper;
        public int GenreID { get; set; }
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres
                .Where(genre => genre.IsActive && GenreID== genre.Id)
                .OrderBy(genre => genre.Id);
            if (genre is null)
                throw new Exception("Kitap Türü Bulunamadı.");
            else
                return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
