using FluentValidation;

namespace MovieStore.Application.Operations.Entities.Customer.Commands.Delete
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
