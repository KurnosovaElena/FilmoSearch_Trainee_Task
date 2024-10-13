namespace FilmoSearch.DataAcessLayer.Entities
{
    public class Film
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public IEnumerable<Actor>? Actors { get; set; }
        public IEnumerable<Review>? Reviews { get; set; }
    }
}
