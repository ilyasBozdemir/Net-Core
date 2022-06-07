using FluentValidation;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;

namespace WebApi.Application.GenreOperations.Commands
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(data => data._model.Name).MinimumLength(4);
        }
    }
}
