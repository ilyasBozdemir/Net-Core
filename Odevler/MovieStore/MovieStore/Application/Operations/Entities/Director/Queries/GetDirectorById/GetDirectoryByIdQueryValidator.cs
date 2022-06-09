using FluentValidation;
namespace MovieStore.Application.Operations.Entities.Director.Queries.GetDirectorById
{
    public class GetDirectorByIdQueryValidator : AbstractValidator<GetDirectorByIdQuery>
    {
        public GetDirectorByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
