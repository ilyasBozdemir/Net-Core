using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands
{
    public class UpdateGenreCommand
    {
        public readonly BookStoreDbContext _context;
        public UpdateGenreModel _model { get; set; }
        public int GenreID { get; set; }

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres
                .SingleOrDefault(x => x.Id == GenreID);
            if (genre is not null)
                throw new InvalidOperationException("Kitap Türü  Bulunamadı.");
            if (_context.Genres.Any(x => x.Name.ToLower() == _model.Name.ToLower() && x.Id != GenreID))
                throw new InvalidOperationException("Aynı isimde bir kitap türü zaten mevcut");

            genre.Name = _model.Name.Trim() == default
                ? _model.Name
                : genre.Name;
            genre.IsActive = _model.IsActive;

            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
