using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.UnitOfWork;
using MediatR; 

namespace Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customer;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(
                ICustomerRepository customer,
             IUnitOfWork unitOfWork)
        {
            _customer = customer;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customer.GetCustomer(command.Id, cancellationToken);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }
             
            foreach (var medicalPolicy in customer.MedicalPolicies)
            {
                medicalPolicy.IsActive = false;
                medicalPolicy.CustomerId = null;
            }

            foreach (var travelPolicy in customer.TravelPolicies)
            {
                travelPolicy.IsActive = false;
                travelPolicy.CustomerId = null;
            }
             
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
