using MediatR;
using Application.Common.Contracts.Persistence.Command; 
using Application.Common.Contracts.Persistence.UnitOfWork;
using Domain.Entities;
using Domain;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public class CreateMedicalCommandHandler : IRequestHandler<CreateMedicalCommands, CreateMedicalCommandResponse>
    { 
        private readonly IUnitOfWork _unitOfWork;

        public CreateMedicalCommandHandler(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
         
        public async Task<CreateMedicalCommandResponse> Handle(CreateMedicalCommands command, CancellationToken cancellationToken)
        {
            try
            {

                foreach (CreateMedicalCommand request in command.Commands)
                {
                    Customer customer;
                    var existingCustomer = await _unitOfWork.Customers.FindAsync(x => x.IdNumber == request.IdNumber, cancellationToken);
                    if (existingCustomer is not null && existingCustomer.IsDeleted)
                    {
                        customer = existingCustomer;
                    }
                    else
                    {
                        customer = new Customer
                        {
                            Id = Guid.NewGuid(),
                            CreateDate = DateTime.Now,
                            IdNumber = request.IdNumber,
                            PassportNumber = request.IdNumber,
                            DateOfBirth = request.DateOfBirth,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            PhoneNumber = request.PhoneNumber,
                            Email = request.Email,
                            Gender = request.Gender,
                            Citizenship = request.Citizenship,
                            Address = request.Address
                        };
                        await _unitOfWork.Customers.AddAsync(customer, cancellationToken);
                    }
                    
                    var policy = new MedicalPolicy
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        CustomerId = customer.Id,
                        PolicyNumber = new PolicyNumberGenerator().GenerateRandomPolicyNumber(),
                        TypeOfPaymentPeriod = request.TypeOfPaymentPeriod,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        PremiumAmount = request.PremiumAmount,
                        Provider = request.Provider,
                        Insurer = customer.IdNumber
                    };

                    await _unitOfWork.MedicalRepository.AddAsync(policy, cancellationToken);
                }

                await _unitOfWork.SaveAsync(cancellationToken);
                var item = command.Commands.FirstOrDefault();

                
                return new CreateMedicalCommandResponse($"{item.FirstName} {item.FirstName}", item.Citizenship, item.IdNumber, new DateOnly(item.DateOfBirth.Year, item.DateOfBirth.Month, item.DateOfBirth.Day), item.PhoneNumber, item.Email);


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        } 
    }
}
