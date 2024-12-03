using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using Application.Common.Interfaces.Persistence.Commands;
using Application.Common.Interfaces.Persistence.Queries;
using System.Reflection.Metadata.Ecma335;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public class CreateMedicalCommandHandler : IRequestHandler<CreateMedicalCommand, CreateMedicalCommandResponse>
    {
        private readonly IMedicalRepository _medicalRepository;
        private readonly ICustomerQueryRepository _customerQuery;
        public CreateMedicalCommandHandler(IMedicalRepository medicalRepository,
             ICustomerQueryRepository customerQuery)
        {
            _medicalRepository = medicalRepository;
            _customerQuery = customerQuery;
        }

        public async Task<CreateMedicalCommandResponse> Handle(CreateMedicalCommand request, CancellationToken cancellation)
        {
           var customer = _customerQuery.GetByIdNumber(request.IdNumber);
            // if (customer == null || customer.IsActive is true) { }

           
        }
    }
}
