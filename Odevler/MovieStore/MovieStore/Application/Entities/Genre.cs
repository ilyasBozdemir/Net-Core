using MovieStore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<CustomerGenre> CustomerGenres { get; set; }
    }
}
