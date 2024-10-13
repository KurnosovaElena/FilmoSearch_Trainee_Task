using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FluentValidation;

namespace FilmoSearch_Trainee_Task.Validators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDTO>
    {
        public CreateReviewValidator()
        {

            RuleFor(cr => cr.Title)
                    .NotEmpty()
                    .MaximumLength(50);

            RuleFor(cr => cr.Stars)
                    .NotEmpty()
                    .InclusiveBetween(0, 5);

            RuleFor(cr => cr.FilmId)
                    .NotEmpty();
        }
    }
}
