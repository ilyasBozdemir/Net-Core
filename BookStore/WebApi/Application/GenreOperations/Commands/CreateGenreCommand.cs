using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        public CreateGenreModel _model { get; set; }
        public readonly BookStoreDbContext _context;

        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres
                .SingleOrDefault(g=> g.Name == _model.Name);
            if (genre is not null)
                throw new InvalidOperationException("Kitap Türü Zaten Önceden Girilmiş.");

            genre = new Entities.Genre();
            genre.Name = _model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}

