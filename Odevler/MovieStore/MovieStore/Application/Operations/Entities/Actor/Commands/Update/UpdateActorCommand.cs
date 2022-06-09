using MovieStore.Application.Operations.Entities.Actor.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Actor.Commands.Update
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int Id { get; set; }
        public UpdateActorModel Model { get; set; }
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            MovieStore.Entities.Actor actor = _context.Actors.SingleOrDefault(actor => actor.Id == Id);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadı.");
            }

            actor.FirstName = string.IsNullOrEmpty(Model.FirstName) ? actor.FirstName : Model.FirstName.Trim();
            actor.LastName = string.IsNullOrEmpty(Model.LastName) ? actor.LastName : Model.LastName.Trim();

            if (_context.Actors.Any(a => a.FirstName.ToLower() == actor.FirstName.ToLower() && a.LastName.ToLower() == actor.LastName.ToLower() && a.Id != actor.Id))
            {
                throw new InvalidOperationException("Bu isimde bir oyuncu zaten var.");
            }
            _context.SaveChanges();
        }
    }
}
