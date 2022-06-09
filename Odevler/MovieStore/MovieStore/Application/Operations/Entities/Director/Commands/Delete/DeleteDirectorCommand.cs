using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Director.Commands.Delete
{
    public class DeleteDirectorCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            MovieStore.Entities. Director director = _context.Directors.SingleOrDefault(director => director.Id == Id);
            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı.");
            }
            bool isDirectingAnyMovie = _context.Movies.Include(movie => movie.Director).Any(movie => movie.isActive && movie.DirectorId == director.Id);

            if (isDirectingAnyMovie)
            {
                throw new InvalidOperationException("Bu yönetmen bir film yönetmektedir, şu anda silinemez.");
            }

            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
