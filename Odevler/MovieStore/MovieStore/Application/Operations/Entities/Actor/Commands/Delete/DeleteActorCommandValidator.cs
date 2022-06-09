using FluentValidation;

namespace MovieStore.Application.Operations.Entities.Actor.Commands.Delete
{
    public class DeleteActorCommandValidator: AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(cmd => cmd.Id).GreaterThan(0);
        }
    }
}
