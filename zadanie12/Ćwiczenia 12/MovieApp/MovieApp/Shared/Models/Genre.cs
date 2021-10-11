using System.Collections.Generic;

namespace MovieApp.Shared.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set; } = new List<MoviesGenres>();
    }
}
