using FluentValidation;
namespace MovieStore.Application.Operations.Entities.Director.Commands.Delete
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
