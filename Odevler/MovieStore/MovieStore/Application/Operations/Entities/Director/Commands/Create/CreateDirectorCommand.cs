using AutoMapper;
using MovieStore.Application.Operations.Entities.Director.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Director.Commands.Create
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            MovieStore.Entities. Director director = _context.Directors.SingleOrDefault(director => (director.FirstName == Model.FirstName && director.LastName == Model.LastName));
            if (director is not null)
            {
                throw new InvalidOperationException("Yönetmen zaten mevcut.");
            }

            director = _mapper.Map<MovieStore.Entities.Director>(Model);

            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }
}
