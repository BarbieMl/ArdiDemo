using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetCustomer;
using FluentValidation;

namespace API.Validators
{
    public class GetByIdCommandValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetByIdCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id Can't be empty");
        }
    }

    public class DeletePolicyHolderCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeletePolicyHolderCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id Can't be empty");
        }
    }

    public class UpdateCustomerPolicyCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerPolicyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id Can't be empty");

            RuleFor(x => x.IdNumber)
                .NotEmpty()
                .WithMessage("IdNumber Can't be empty");
        }
    }
}
