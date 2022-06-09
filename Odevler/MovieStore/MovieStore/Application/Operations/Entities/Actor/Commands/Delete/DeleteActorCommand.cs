using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Actor.Commands.Delete
{
    public class DeleteActorCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;

        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            MovieStore.Entities.Actor actor = _context.Actors.SingleOrDefault(actor => actor.Id == Id);
            if (actor is null)
                throw new InvalidOperationException("Oyuncu bulunamadı.");


            var isPlayingInAnyMovie = _context.Movies.Include(movie => movie.Actors).Any(movie => movie.isActive && movie.Actors.Any(a => a.Id == actor.Id));

            if (isPlayingInAnyMovie)
            
                throw new InvalidOperationException("Bu oyuncu bir filmde oynamaktadır, şu anda silinemez.");
            

            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}
