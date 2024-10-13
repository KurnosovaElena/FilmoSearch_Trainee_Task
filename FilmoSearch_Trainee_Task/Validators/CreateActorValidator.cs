using FilmoSearch.BusinessLogicLayer.DataTransferObjects.CreateDTOs;
using FluentValidation;

namespace FilmoSearch_Trainee_Task.Validators
{
    public class CreateActorValidator : AbstractValidator<CreateActorDTO>
    {
        public CreateActorValidator()
        {
            RuleFor(ca => ca.FirstName)
                .NotEmpty()
                .MaximumLength(25)
                .WithMessage("Actor first name length should not exceed 25 characters");

            RuleFor(ca => ca.LastName)
                .NotEmpty()
                .MaximumLength(25)
                .WithMessage("Actor last name length should not exceed 25 characters");
        }
    }
}
