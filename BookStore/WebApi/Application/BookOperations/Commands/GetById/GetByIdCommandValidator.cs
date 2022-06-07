using FluentValidation;

namespace WebApi.BookOperations.GetById
{
    public class GetByIdCommandValidator : AbstractValidator<BookModel>
    {
        public GetByIdCommandValidator()
        {
            RuleFor(cmd => cmd.GenreId).GreaterThan(0);
            RuleFor(cmd => cmd.PageCount).GreaterThan(0);
            RuleFor(cmd => cmd.PublishDate.Date)
                .NotEmpty()
                .LessThan(DateTime.Now.Date);
        }
    }
}
