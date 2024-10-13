using FilmoSearch.DataAcessLayer.Entities;

namespace FilmoSearch.BusinessLogicLayer.DataTransferObjects
{
    public class ReviewDTO : CreateDTOs.CreateReviewDTO
    {
        public int Id { get; set; }
        public Film? Film { get; set; }

    }
}
