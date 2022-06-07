using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(data => data.GenreID).GreaterThan(4);
        }
    }
}
