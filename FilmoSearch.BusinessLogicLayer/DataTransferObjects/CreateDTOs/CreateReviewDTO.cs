namespace FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs
{
    public class CreateReviewDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Stars { get; set; }
        public int FilmId { get; set; }
    }
}
