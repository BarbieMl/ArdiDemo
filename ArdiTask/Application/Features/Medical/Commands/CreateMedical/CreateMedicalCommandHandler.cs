using MediatR;
using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using Domain.Entities;
using Application.Common.Contracts.Persistence.UnitOfWork;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public class CreateMedicalCommandHandler : IRequestHandler<CreateMedicalCommands, CreateMedicalCommandResponse>
    {
        private readonly IMedicalRepository _medicalRepository;
        private readonly ICustomerQueryRepository _customerQuery;
        private readonly ICustomerRepository _customer;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMedicalCommandHandler(IMedicalRepository medicalRepository,
             ICustomerQueryRepository customerQuery,
             ICustomerRepository customer,
             IUnitOfWork unitOfWork)
        {
            _medicalRepository = medicalRepository;
            _customerQuery = customerQuery;
            _customer = customer;
            _unitOfWork = unitOfWork;   
        }
         
        public async Task<CreateMedicalCommandResponse> Handle(CreateMedicalCommands command, CancellationToken cancellationToken)
        {
            try
            {

                foreach (CreateMedicalCommand request in command.Commands)
                {
                    Customer customer;
                    var existingCustomer = await _customerQuery.GetByIdNumber(request.IdNumber);
                    if (existingCustomer is not null && existingCustomer.IsActive)
                    {
                        customer = existingCustomer;
                    }
                    else
                    {
                        customer = new Customer
                        {
                            Id = Guid.NewGuid(),
                            IdNumber = request.IdNumber,
                            DateOfBirth = request.DateOfBirth,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            PhoneNumber = request.PhoneNumber,
                            Email = request.Email,
                            Gender = request.Gender,
                            Citizenship = request.Citizenship,
                            Address = request.Address
                        };
                    }
                    await _customer.AddAsync(customer);
                    await _customer.SaveAsync();

                    var policy = new MedicalPolicy
                    {
                        CustomerId = customer.Id,
                        PolicyNumber = $"P{Guid.NewGuid().ToString("N").Substring(0, 10)}",
                        TypeOfPaymentPeriod = request.TypeOfPaymentPeriod,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        PremiumAmount = request.PremiumAmount,
                        Provider = request.Provider,
                        Insurer = customer.IdNumber
                    };

                    await _medicalRepository.AddAsync(policy);
                   await _medicalRepository.SaveAsync(); 
                }

               // await _unitOfWork.SaveAsync(cancellationToken);
                var item = command.Commands.FirstOrDefault();
                //var item = await _customerQuery.GetByIdNumber(command.Commands[0].IdNumber);


                return new CreateMedicalCommandResponse($"{item.FirstName} {item.FirstName}", item.Citizenship, item.IdNumber, item.DateOfBirth, item.PhoneNumber, item.Email);


            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

    }
}
