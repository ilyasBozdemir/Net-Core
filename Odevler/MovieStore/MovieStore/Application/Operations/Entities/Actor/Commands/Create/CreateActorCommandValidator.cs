using FluentValidation;

namespace MovieStore.Application.Operations.Entities.Actor.Commands.Create
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(cmd => cmd.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(cmd => cmd.Model.LastName).NotEmpty().MinimumLength(4);
        }
    }
}
