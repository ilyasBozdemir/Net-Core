
using MovieStore.Entities;

namespace MovieStore.Entities
{
    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public int GenreId { get; set; }

        public Customer Customer { get; set; }
        public Genre Genre { get; set; }
    }
}
