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
        private readonly IMedicalRepository _medical;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMedicalCommandHandler(
                IMedicalRepository medical,
             IUnitOfWork unitOfWork)
        {
            _medical = medical;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteMedicalCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _medical.FindAsync(x => x.Id == command.Id);
            if (existingRecord is null || !existingRecord.IsActive)
            {
                throw new KeyNotFoundException("Medical record not found.");
            }

            existingRecord.IsActive = false;

            await _medical.Update(existingRecord);
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
