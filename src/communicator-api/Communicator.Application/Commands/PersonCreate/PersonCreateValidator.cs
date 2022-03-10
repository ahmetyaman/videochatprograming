using FluentValidation;

namespace Communicator.Application.Commands.PersonCreate
{
    public class PersonCreateValidator : AbstractValidator<PersonCreateCommand>
    {
        public PersonCreateValidator()
        {
            RuleFor(r => r.Email).EmailAddress().NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.SurName).NotEmpty();
        }
    }
}