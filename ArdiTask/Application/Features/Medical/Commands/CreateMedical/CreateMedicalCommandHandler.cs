using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using Application.Interfaces.Persistence;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public class CreateMedicalCommandHandler : IRequestHandler<CreateMedicalCommand, CreateMedicalCommandResponse>
    {
        private readonly IMedicalRepository _medicalRepository;
        public CreateMedicalCommandHandler(IMedicalRepository medicalRepository)
        {
            _medicalRepository = medicalRepository;
        }

        public async Task<CreateMedicalCommandResponse> Handle(CreateMedicalCommand request, CancellationToken cancellation)
        {

        }
    }
}
