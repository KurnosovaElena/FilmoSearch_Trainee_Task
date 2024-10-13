using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FluentValidation;

namespace FilmoSearch_Trainee_Task.Validators
{
    public class CreateFilmValidator : AbstractValidator<CreateFilmDTO>
    {
        public CreateFilmValidator()
        {
            RuleFor(cf => cf.Title)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
