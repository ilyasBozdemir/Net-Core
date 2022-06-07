using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Application.GenreOperations.Commands
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(cmd => cmd._model.Name)
                .MinimumLength(4)
                .When(cmd => cmd._model.Name.Trim() != String.Empty);
        }
    }
}
