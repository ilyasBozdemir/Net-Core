
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<Actor> Actors { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; } = true;
        public object Director { get; internal set; }
        public object Genre { get; internal set; }
    }
}