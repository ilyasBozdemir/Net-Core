using FluentValidation;
namespace MovieStore.Application.Operations.Entities.Director.Commands.Create
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(1);
        }
    }
}
