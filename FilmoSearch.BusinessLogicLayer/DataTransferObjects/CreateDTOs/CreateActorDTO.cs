using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs
{
    public class CreateActorDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public IEnumerable<Film>? Films { get; set; }
    }
}
