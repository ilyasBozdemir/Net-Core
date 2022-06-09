using MovieStore.Application.Operations.Entities.Director.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Director.Commands.Update
{
    public class UpdateDirectorCommand
    {
        public int Id { get; set; }
        public UpdateDirectorModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;

        public UpdateDirectorCommand(IMovieStoreDbContext context)
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

            director.FirstName = string.IsNullOrEmpty(Model.FirstName) ? director.FirstName : Model.FirstName.Trim();
            director.LastName = string.IsNullOrEmpty(Model.LastName) ? director.LastName : Model.LastName.Trim();

            if (_context.Directors.Any(d => d.FirstName.ToLower() == director.FirstName.ToLower() && d.LastName.ToLower() == director.LastName.ToLower() && d.Id != director.Id))
            {
                throw new InvalidOperationException("Bu isimde bir yönetmen zaten var.");
            }
            _context.SaveChanges();
        }
    }
}
