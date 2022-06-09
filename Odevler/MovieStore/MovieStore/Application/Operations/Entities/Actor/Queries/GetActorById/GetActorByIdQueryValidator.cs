using FluentValidation;

namespace MovieStore.Application.Operations.Entities.Actor.Queries.GetActorById
{
    public class GetActorByIdQueryValidator : AbstractValidator<GetActorByIdQuery>
    {
        public GetActorByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
