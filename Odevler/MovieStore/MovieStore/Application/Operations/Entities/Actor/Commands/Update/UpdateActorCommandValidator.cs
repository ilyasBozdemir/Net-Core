using FluentValidation;

namespace MovieStore.Application.Operations.Entities.Actor.Commands.Update
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(cmd => cmd.Id).GreaterThan(0);
            RuleFor(cmd => cmd.Model.FirstName).MinimumLength(1).When(cmd => cmd.Model.FirstName != string.Empty);
            RuleFor(cmd => cmd.Model.LastName).MinimumLength(1).When(cmd => cmd.Model.LastName != string.Empty);
        }
    }
}
