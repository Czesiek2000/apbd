namespace MovieApp.Shared.Models
{
    public class MoviesActors
    {
        public int PersonId { get; set; }
        public int MovieId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Movie Movie { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
