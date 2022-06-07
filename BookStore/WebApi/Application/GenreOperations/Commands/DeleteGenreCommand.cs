using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres
                .SingleOrDefault(x => x.Id == GenreId);
            if (genre is not null)
                throw new InvalidOperationException("Kitap Türü Bulunamadı.");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
