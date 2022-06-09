using FluentValidation;

namespace MovieStore.Application.Operations.Entities.Customer.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4).EmailAddress();
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
        }
    }
}
