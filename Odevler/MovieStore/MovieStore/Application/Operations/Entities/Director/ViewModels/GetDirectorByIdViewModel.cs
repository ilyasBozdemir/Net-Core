namespace MovieStore.Application.Operations.Entities.Director.ViewModels
{
    public class GetDirectorByIdViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<DirectedMovieViewModel> DirectedMovies { get; set; }
    }
}
