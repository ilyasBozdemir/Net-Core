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
    }
}
