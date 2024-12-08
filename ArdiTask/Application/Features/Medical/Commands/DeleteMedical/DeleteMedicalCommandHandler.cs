using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.UnitOfWork;
using Application.Features.Medical.Commands.UpdateMedical;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Commands.DeleteMedical
{
    public class DeleteMedicalCommandHandler : IRequestHandler<DeleteMedicalCommand, bool>
    { 
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedicalCommandHandler( 
             IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteMedicalCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _unitOfWork.MedicalRepository.FindAsync(x => x.Id == command.Id, cancellationToken);
            if (existingRecord is null || !existingRecord.IsDeleted)
            {
                throw new KeyNotFoundException("Medical record not found.");
            }
            await _unitOfWork.MedicalRepository.Delete(existingRecord, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
