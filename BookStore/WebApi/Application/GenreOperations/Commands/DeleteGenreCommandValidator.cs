using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Application.GenreOperations.Commands
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(data => data.GenreId).GreaterThan(0);
        }
    }
}
