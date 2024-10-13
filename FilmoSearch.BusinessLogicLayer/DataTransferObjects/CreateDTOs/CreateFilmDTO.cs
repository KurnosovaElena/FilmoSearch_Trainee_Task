using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs
{
    public class CreateFilmDTO
    {
        public string Title { get; set; } = string.Empty;

        public IEnumerable<Actor>? Actors { get; set; }
        public IEnumerable<Review>? Reviews { get; set; }
    }
}
