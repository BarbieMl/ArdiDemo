using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.UnitOfWork;
using Domain.Entities;
using MediatR; 

namespace Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    { 
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler( 
                IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork; ;
        }

        public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Customers.GetCustomer(command.Id, cancellationToken);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            await _unitOfWork.Customers.Delete(customer, cancellationToken);

            if (customer.MedicalPolicies != null)
            {
                foreach (var medicalPolicy in customer.MedicalPolicies)
                {
                    await _unitOfWork.MedicalRepository.Delete(medicalPolicy, cancellationToken);
                }
            }
            if (customer.TravelPolicies != null)
            {
                foreach (var travelPolicy in customer.TravelPolicies)
                {
                    await _unitOfWork.TravelRepository.Delete(travelPolicy, cancellationToken);
                }
            }
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
