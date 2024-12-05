using MediatR;
using Application.Common.Contracts.Persistence.Command; 
using Application.Common.Contracts.Persistence.UnitOfWork;
using Domain.Entities;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public class CreateMedicalCommandHandler : IRequestHandler<CreateMedicalCommands, CreateMedicalCommandResponse>
    {
        private readonly IMedicalRepository _medicalRepository;
        private readonly ICustomerRepository _customer;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMedicalCommandHandler(IMedicalRepository medicalRepository, 
             ICustomerRepository customer,
             IUnitOfWork unitOfWork)
        {
            _medicalRepository = medicalRepository;
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
                    var existingCustomer = await _customer.FindAsync(x => x.IdNumber == request.IdNumber);
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
                            PassportNumber = "9090909",
                            DateOfBirth = request.DateOfBirth,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            PhoneNumber = request.PhoneNumber,
                            Email = request.Email,
                            Gender = request.Gender,
                            Citizenship = request.Citizenship,
                            Address = request.Address,
                            IsActive = true
                        };
                        await _customer.AddAsync(customer);
                    }

                    var policy = new MedicalPolicy
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = customer.Id,
                        PolicyNumber = $"P{Guid.NewGuid().ToString("N").Substring(0, 10)}",
                        TypeOfPaymentPeriod = request.TypeOfPaymentPeriod,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        PremiumAmount = request.PremiumAmount,
                        Provider = request.Provider,
                        Insurer = customer.IdNumber,
                        IsActive = true
                    };

                    await _medicalRepository.AddAsync(policy);
                }

                await _unitOfWork.SaveAsync(cancellationToken);
                var item = command.Commands.FirstOrDefault();


                return new CreateMedicalCommandResponse($"{item.FirstName} {item.FirstName}", item.Citizenship, item.IdNumber, item.DateOfBirth, item.PhoneNumber, item.Email);


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

    }
}
